namespace Utils
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Globalization;
	using System.Threading;

	/// <summary>
	/// A replacement for BitArray
	/// </summary>
	public class BoolArray : IEnumerable, ICollection,  ICloneable
	{
		private UInt32[] bits = null;
		private int _length = 0;
		private static UInt32 ONE = (UInt32)1 << 31;
		private object _syncRoot;
		private static Func<byte[], byte[]> EndianFixer = null;

		#region Constructors

		static BoolArray()
		{
			if (BitConverter.IsLittleEndian) EndianFixer = (a) => a.Reverse().ToArray();
			else EndianFixer = (a) => a;
		}

		public BoolArray(BoolArray srcBits)
		{
			this.InitializeFrom(srcBits.ToArray());
		}

		public BoolArray(ICollection<bool> srcBits)
		{
			this.InitializeFrom(srcBits.ToArray());
		}

		public BoolArray(ICollection<byte> srcBits)
		{
			InitializeFrom(srcBits);
		}

		public BoolArray(ICollection<short> srcBits)
		{
			ICollection<byte> bytes = srcBits.SelectMany(v => EndianFixer(BitConverter.GetBytes(v))).ToList();
			InitializeFrom(bytes);
		}

		public BoolArray(ICollection<ushort> srcBits)
		{
			ICollection<byte> bytes = srcBits.SelectMany(v => EndianFixer(BitConverter.GetBytes(v))).ToList();
			InitializeFrom(bytes);
		}

		public BoolArray(ICollection<int> srcBits)
		{
			ICollection<byte> bytes = srcBits.SelectMany(v => EndianFixer(BitConverter.GetBytes(v))).ToList();
			InitializeFrom(bytes);
		}

		public BoolArray(ICollection<uint> srcBits)
		{
			ICollection<byte> bytes = srcBits.SelectMany(v => EndianFixer(BitConverter.GetBytes(v))).ToList();
			InitializeFrom(bytes);
		}

		public BoolArray(ICollection<long> srcBits)
		{
			ICollection<byte> bytes = srcBits.SelectMany(v => EndianFixer(BitConverter.GetBytes(v))).ToList();
			InitializeFrom(bytes);
		}

		public BoolArray(ICollection<ulong> srcBits)
		{
			ICollection<byte> bytes = srcBits.SelectMany(v => EndianFixer(BitConverter.GetBytes(v))).ToList();
			InitializeFrom(bytes);
		}

		public BoolArray(int capacity, bool defaultValue = false)
		{
			this.bits = new UInt32[RequiredSize(capacity)];
			this._length = capacity;

			// Only need to do this if true, because default for all bits is false
			if (defaultValue) for (int i = 0; i < this._length; i++) this[i] = true;
		}

		private void InitializeFrom(ICollection<byte> srcBits)
		{
			this._length = srcBits.Count * 8;
			this.bits = new UInt32[RequiredSize(this._length)];
			for (int i = 0; i < srcBits.Count; i++)
			{
				uint bv = srcBits.Skip(i).Take(1).Single();
				for (int b = 0; b < 8; b++)
				{
					bool bitVal = ((bv << b) & 0x0080) != 0;
					int bi = 8 * i + b;
					this[bi] = bitVal;
				}
			}
		}

		private void InitializeFrom(ICollection<bool> srcBits)
		{
			this._length = srcBits.Count;
			this.bits = new UInt32[RequiredSize(this._length)];

			int index = 0;
			foreach (var b in srcBits) this[index++] = b;
		}

		private static int RequiredSize(int bitCapacity)
		{
			return (bitCapacity + 31) >> 5;
		}

		#endregion


		public bool this[int index]
		{
			get
			{
				if (index >= _length) throw new IndexOutOfRangeException();

				int byteIndex = index >> 5;
				int bitIndex = index & 0x1f;
				return ((bits[byteIndex] << bitIndex) & ONE) != 0;
			}
			set
			{
				if (index >= _length) throw new IndexOutOfRangeException();

				int byteIndex = index >> 5;
				int bitIndex = index & 0x1f;
				if (value) bits[byteIndex] |= (ONE >> bitIndex);
				else bits[byteIndex] &= ~(ONE >> bitIndex);
			}
		}

		#region IEnumerable
		public IEnumerator GetEnumerator()
		{
			//for (int i = 0; i < _length; i++) yield return this[i];
			return this.ToArray().GetEnumerator();
		} 
		#endregion
		#region ICollection
		public void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();

			if (array == null) throw new ArgumentNullException("array");
			if (index < 0) throw new ArgumentOutOfRangeException("index");
			if (array.Rank != 1) throw new ArgumentException("Multidimentional array not supported");
			//if (array is UInt32[]) Array.Copy((Array)this.m_array, 0, array, index, BitArray.GetArrayLength(this.m_length, 32));
			//else if (array is byte[])
			//else if (array is bool[])
		}

		public int Count
		{
			get { return this._length; }
		}

		public bool IsSynchronized
		{
			get { return false; }
		}

		public object SyncRoot
		{
			get
			{
				if (this._syncRoot == null) Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), null);
				return _syncRoot;
			}
		}
		#endregion
		#region ICloneable
		public object Clone()
		{
			return new BoolArray(this.ToArray());
		} 
		#endregion

		public bool[] ToArray()
		{
			bool[] vbits = new bool[this._length];
			for (int i = 0; i < _length; i++) vbits[i] = this[i];
			return vbits;
		}

		public BoolArray Append(ICollection<bool> addBits)
		{
			int startPos = this._length;
			Extend(addBits.Count);
			bool[] bitArray = addBits.ToArray();
			for (int i = 0; i < bitArray.Length; i++) this[i + startPos] = bitArray[i];
			return this;
		}

		public BoolArray Append(BoolArray addBits)
		{
			return this.Append(addBits.ToArray());
		}

		public void Extend(int numBits)
		{
			numBits += this._length;
			int reqBytes = RequiredSize(numBits);
			if (reqBytes > this.bits.Length)
			{
				UInt32[] newBits = new UInt32[reqBytes];
				this.bits.CopyTo(newBits, 0);
				this.bits = newBits;
			}
			this._length = numBits;
		}

		public BoolArray Reverse()
		{
			this.InitializeFrom(this.ToArray().Reverse().ToList());
			return this;
		}

		public static BoolArray operator +(BoolArray a, BoolArray b)
		{
			return new BoolArray(a).Append(b);
		}

		public static BoolArray FromHexString(string hex)
		{
			if (hex == null) throw new ArgumentNullException("hex");

			List<bool> bits = new List<bool>();
			for (int i = 0; i < hex.Length; i++)
			{
				int b = byte.Parse(hex[i].ToString(), NumberStyles.HexNumber);
				bits.Add((b >> 3) == 1);
				bits.Add(((b & 0x7) >> 2) == 1);
				bits.Add(((b & 0x3) >> 1) == 1);
				bits.Add((b & 0x1) == 1);
			}
			BoolArray ba = new BoolArray(bits.ToArray());
			return ba;
		}

		public static BoolArray FromBinaryString(string bin, char[] trueChars = null)
		{
			if (trueChars == null) trueChars = new char[] { '1', 'Y', 'y', 'T', 't' };
			if (bin == null) throw new ArgumentNullException("bin");
			BoolArray ba = new BoolArray(bin.Length);
			for (int i = 0; i < bin.Length; i++) ba[i] = bin[i].In(trueChars);
			return ba;
		}

		public BoolArray Repeat(int numReps)
		{
			BoolArray dv = new BoolArray(0);
			while (--numReps >= 0) dv = dv.Append(this);
			return dv;
		}

		public BoolArray GetBits(int startBit = 0, int numBits = -1)
		{
			if (numBits == -1) numBits = bits.Length;
			return new BoolArray(this.ToArray().Skip(startBit).Take(numBits).ToArray());
		}

		public BoolArray SetBits(int startBit, BoolArray setBits)
		{
			int diffSize = startBit + setBits.Count - this.Count;
			if (diffSize > 0) Extend(diffSize);
			for (int i = 0; i < setBits.Count; i++) this[startBit + i] = setBits[i];
			return this;
		}

		public List<BoolArray> SplitEvery(int numBits)
		{
			int i = 0;
			List<BoolArray> bitSplits = new List<BoolArray>();
			while (i < this.Count)
			{
				bitSplits.Add(this.GetBits(i, numBits));
				i += numBits;
			}
			return bitSplits;
		}

		#region Logical Bitwise Operations
		public static BoolArray BinaryBitwiseOp(Func<bool, bool, bool> op, BoolArray left, BoolArray right, int start = 0)
		{
			bool[] leftbits = left.ToArray();
			bool[] rightbits = right.ToArray();
			for (int i = 0; i < rightbits.Length; i++)
			{
				if (start + i >= leftbits.Length) break;
				leftbits[start + i] = op(leftbits[start + i], rightbits[i]);
			}
			return new BoolArray(leftbits);
		}

		public BoolArray Xor(BoolArray xor, int start = 0)
		{
			return BinaryBitwiseOp((a, b) => (a ^ b), this, xor, start);
		}

		public BoolArray And(BoolArray and, int start = 0)
		{
			return BinaryBitwiseOp((a, b) => (a & b), this, and, start);
		}

		public BoolArray Or(BoolArray or, int start = 0)
		{
			return BinaryBitwiseOp((a, b) => (a | b), this, or, start);
		}

		public BoolArray Not(int start = 0, int len = -1)
		{
			BoolArray b = (BoolArray)this.Clone();
			for (int i = start; i < b.Count; i++)
			{
				if (--len == -1) break;
				b[i] = !b[i];
			}
			return b;
		} 
		#endregion

		public string ToHexString(string bitSep8 = null, string bitSep128 = null)
		{
			string s = string.Empty;
			int b = 0;
			bool[] bbits = this.ToArray();

			for (int i = 1; i <= bbits.Length; i++)
			{
				b = (b << 1) | (bbits[i - 1] ? 1 : 0);
				if (i % 4 == 0)
				{
					s = s + string.Format("{0:x}", b);
					b = 0;
				}

				if (i % (8 * 16) == 0)
				{
					s = s + bitSep128;
				}
				else if (i % 8 == 0)
				{
					s = s + bitSep8;
				}
			}
			int ebits = bbits.Length % 4;
			if (ebits != 0)
			{
				b = b << (4 - ebits);
				s = s + string.Format("{0:x}", b);
			}
			return s;
		}

		public string ToBinaryString(char setChar = '1', char unsetChar = '0')
		{
			return new string(this.ToArray().Select(v => v ? setChar : unsetChar).ToArray());
		}

		public byte[] ToBytes(int startBit = 0, int numBits = -1)
		{
			if (numBits == -1) numBits = bits.Length - startBit;
			BoolArray ba = GetBits(startBit, numBits);
			int nb = (numBits + 7) / 8;
			byte[] bb = new byte[nb];
			for (int i = 0; i < ba.Count; i++)
			{
				if (!ba[i]) continue;
				int bp = 7 - (i % 8);
				bb[i / 8] = (byte)((int)bb[i / 8] | (1 << bp));
			}
			return bb;
		}

		public override string ToString()
		{
			return ToHexString(" ", " ■ ");
		}
	}

	public static class Misc
	{
		public static bool In<T>(this T v, IEnumerable<T> vList) { return vList.Contains(v); }
		public static bool In<T>(this T v, params T[] vList) { return vList.Contains(v); }
		public static void Swap<T>(ref T rw, ref T rh)
		{
			T t = rw;
			rw = rh;
			rh = t;
		}
	}
}