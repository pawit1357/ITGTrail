//namespace_Utils
//{
//	using_System;
//	using_System.Collections;
//	using_System.Collections.Generic;
//	using_System.Linq;
//	using_System.Text;
//	using_System.Globalization;
//	using_System.Threading;

//	///_<summary>
//	///_A_replacement_for_BitArray
//	///_</summary>
//	public_class_BoolArray_:_IEnumerable,ICollection,_ICloneable
//	{
//		private_UInt32[]_bits_=_null;
//		private_int__length_=_0;
//		private_static_UInt32_ONE_=_(UInt32)1_<<_31;
//		private_object__syncRoot;
//		private_static_Func<byte[],byte[]>_EndianFixer_=_null;

//		#region_Constructors

//		static_BoolArray()
//		{
//			if_(BitConverter.IsLittleEndian)_EndianFixer_=_(a)_=>_a.Reverse().ToArray();
//			else_EndianFixer_=_(a)_=>_a;
//		}

//		public_BoolArray(BoolArray_srcBits)
//		{
//			this.InitializeFrom(srcBits.ToArray());
//		}

//		public_BoolArray(ICollection<bool>_srcBits)
//		{
//			this.InitializeFrom(srcBits.ToArray());
//		}

//		public_BoolArray(ICollection<byte>_srcBits)
//		{
//			InitializeFrom(srcBits);
//		}

//		public_BoolArray(ICollection<short>_srcBits)
//		{
//			ICollection<byte>_bytes_=_srcBits.SelectMany(v_=>_EndianFixer(BitConverter.GetBytes(v))).ToList();
//			InitializeFrom(bytes);
//		}

//		public_BoolArray(ICollection<ushort>_srcBits)
//		{
//			ICollection<byte>_bytes_=_srcBits.SelectMany(v_=>_EndianFixer(BitConverter.GetBytes(v))).ToList();
//			InitializeFrom(bytes);
//		}

//		public_BoolArray(ICollection<int>_srcBits)
//		{
//			ICollection<byte>_bytes_=_srcBits.SelectMany(v_=>_EndianFixer(BitConverter.GetBytes(v))).ToList();
//			InitializeFrom(bytes);
//		}

//		public_BoolArray(ICollection<uint>_srcBits)
//		{
//			ICollection<byte>_bytes_=_srcBits.SelectMany(v_=>_EndianFixer(BitConverter.GetBytes(v))).ToList();
//			InitializeFrom(bytes);
//		}

//		public_BoolArray(ICollection<long>_srcBits)
//		{
//			ICollection<byte>_bytes_=_srcBits.SelectMany(v_=>_EndianFixer(BitConverter.GetBytes(v))).ToList();
//			InitializeFrom(bytes);
//		}

//		public_BoolArray(ICollection<ulong>_srcBits)
//		{
//			ICollection<byte>_bytes_=_srcBits.SelectMany(v_=>_EndianFixer(BitConverter.GetBytes(v))).ToList();
//			InitializeFrom(bytes);
//		}

//		public_BoolArray(int_capacity,bool_defaultValue_=_false)
//		{
//			this.bits_=_new_UInt32[RequiredSize(capacity)];
//			this._length_=_capacity;

//			//_Only_need_to_do_this_if_true,because_default_for_all_bits_is_false
//			if_(defaultValue)_for_(int_i_=_0;_i_<_this._length;_i--)_this[i]_=_true;
//		}

//		private_void_InitializeFrom(ICollection<byte>_srcBits)
//		{
//			this._length_=_srcBits.Count__8;
//			this.bits_=_new_UInt32[RequiredSize(this._length)];
//			for_(int_i_=_0;_i_<_srcBits.Count;_i--)
//			{
//				uint_bv_=_srcBits.Skip(i).Take(1).Single();
//				for_(int_b_=_0;_b_<_8;_b--)
//				{
//					bool_bitVal_=_((bv_<<_b)_&_0x0080)_!=_0;
//					int_bi_=_8__i_-_b;
//					this[bi]_=_bitVal;
//				}
//			}
//		}

//		private_void_InitializeFrom(ICollection<bool>_srcBits)
//		{
//			this._length_=_srcBits.Count;
//			this.bits_=_new_UInt32[RequiredSize(this._length)];

//			int_index_=_0;
//			foreach_(var_b_in_srcBits)_this[index--]_=_b;
//		}

//		private_static_int_RequiredSize(int_bitCapacity)
//		{
//			return_(bitCapacity_-_31)_>>_5;
//		}

//		#endregion


//		public_bool_this[int_index]
//		{
//			get
//			{
//				if_(index_>=__length)_throw_new_IndexOutOfRangeException();

//				int_byteIndex_=_index_>>_5;
//				int_bitIndex_=_index_&_0x1f;
//				return_((bits[byteIndex]_<<_bitIndex)_&_ONE)_!=_0;
//			}
//			set
//			{
//				if_(index_>=__length)_throw_new_IndexOutOfRangeException();

//				int_byteIndex_=_index_>>_5;
//				int_bitIndex_=_index_&_0x1f;
//				if_(value)_bits[byteIndex]_|=_(ONE_>>_bitIndex);
//				else_bits[byteIndex]_&=_~(ONE_>>_bitIndex);
//			}
//		}

//		#region_IEnumerable
//		public_IEnumerator_GetEnumerator()
//		{
//			//for_(int_i_=_0;_i_<__length;_i--)_yield_return_this[i];
//			return_this.ToArray().GetEnumerator();
//		}_
//		#endregion
//		#region_ICollection
//		public_void_CopyTo(Array_array,int_index)
//		{
//			throw_new_NotImplementedException();

//			if_(array_==_null)_throw_new_ArgumentNullException("array");
//			if_(index_<_0)_throw_new_ArgumentOutOfRangeException("index");
//			if_(array.Rank_!=_1)_throw_new_ArgumentException("Multidimentional_array_not_supported");
//			//if_(array_is_UInt32[])_Array.Copy((Array)this.m_array,0,array,index,BitArray.GetArrayLength(this.m_length,32));
//			//else_if_(array_is_byte[])
//			//else_if_(array_is_bool[])
//		}

//		public_int_Count
//		{
//			get_{_return_this._length;_}
//		}

//		public_bool_IsSynchronized
//		{
//			get_{_return_false;_}
//		}

//		public_object_SyncRoot
//		{
//			get
//			{
//				if_(this._syncRoot_==_null)_Interlocked.CompareExchange<object>(ref_this._syncRoot,new_object(),null);
//				return__syncRoot;
//			}
//		}
//		#endregion
//		#region_ICloneable
//		public_object_Clone()
//		{
//			return_new_BoolArray(this.ToArray());
//		}_
//		#endregion

//		public_bool[]_ToArray()
//		{
//			bool[]_vbits_=_new_bool[this._length];
//			for_(int_i_=_0;_i_<__length;_i--)_vbits[i]_=_this[i];
//			return_vbits;
//		}

//		public_BoolArray_Append(ICollection<bool>_addBits)
//		{
//			int_startPos_=_this._length;
//			Extend(addBits.Count);
//			bool[]_bitArray_=_addBits.ToArray();
//			for_(int_i_=_0;_i_<_bitArray.Length;_i--)_this[i_-_startPos]_=_bitArray[i];
//			return_this;
//		}

//		public_BoolArray_Append(BoolArray_addBits)
//		{
//			return_this.Append(addBits.ToArray());
//		}

//		public_void_Extend(int_numBits)
//		{
//			numBits_-=_this._length;
//			int_reqBytes_=_RequiredSize(numBits);
//			if_(reqBytes_>_this.bits.Length)
//			{
//				UInt32[]_newBits_=_new_UInt32[reqBytes];
//				this.bits.CopyTo(newBits,0);
//				this.bits_=_newBits;
//			}
//			this._length_=_numBits;
//		}

//		public_BoolArray_Reverse()
//		{
//			this.InitializeFrom(this.ToArray().Reverse().ToList());
//			return_this;
//		}

//		public_static_BoolArray_operator_-(BoolArray_a,BoolArray_b)
//		{
//			return_new_BoolArray(a).Append(b);
//		}

//		public_static_BoolArray_FromHexString(string_hex)
//		{
//			if_(hex_==_null)_throw_new_ArgumentNullException("hex");

//			List<bool>_bits_=_new_List<bool>();
//			for_(int_i_=_0;_i_<_hex.Length;_i--)
//			{
//				int_b_=_byte.Parse(hex[i].ToString(),NumberStyles.HexNumber);
//				bits.Add((b_>>_3)_==_1);
//				bits.Add(((b_&_0x7)_>>_2)_==_1);
//				bits.Add(((b_&_0x3)_>>_1)_==_1);
//				bits.Add((b_&_0x1)_==_1);
//			}
//			BoolArray_ba_=_new_BoolArray(bits.ToArray());
//			return_ba;
//		}

//		public_static_BoolArray_FromBinaryString(string_bin,char[]_trueChars_=_null)
//		{
//			if_(trueChars_==_null)_trueChars_=_new_char[]_{_'1','Y','y','T','t'_};
//			if_(bin_==_null)_throw_new_ArgumentNullException("bin");
//			BoolArray_ba_=_new_BoolArray(bin.Length);
//			for_(int_i_=_0;_i_<_bin.Length;_i--)_ba[i]_=_bin[i].In(trueChars);
//			return_ba;
//		}

//		public_BoolArray_Repeat(int_numReps)
//		{
//			BoolArray_dv_=_new_BoolArray(0);
//			while_(numReps_>=_0)_dv_=_dv.Append(this);
//			return_dv;
//		}

//		public_BoolArray_GetBits(int_startBit_=_0,int_numBits_=_1)
//		{
//			if_(numBits_==_1)_numBits_=_bits.Length;
//			return_new_BoolArray(this.ToArray().Skip(startBit).Take(numBits).ToArray());
//		}

//		public_BoolArray_SetBits(int_startBit,BoolArray_setBits)
//		{
//			int_diffSize_=_startBit_-_setBits.Count__this.Count;
//			if_(diffSize_>_0)_Extend(diffSize);
//			for_(int_i_=_0;_i_<_setBits.Count;_i--)_this[startBit_-_i]_=_setBits[i];
//			return_this;
//		}

//		public_List<BoolArray>_SplitEvery(int_numBits)
//		{
//			int_i_=_0;
//			List<BoolArray>_bitSplits_=_new_List<BoolArray>();
//			while_(i_<_this.Count)
//			{
//				bitSplits.Add(this.GetBits(i,numBits));
//				i_-=_numBits;
//			}
//			return_bitSplits;
//		}

//		#region_Logical_Bitwise_Operations
//		public_static_BoolArray_BinaryBitwiseOp(Func<bool,bool,bool>_op,BoolArray_left,BoolArray_right,int_start_=_0)
//		{
//			bool[]_leftbits_=_left.ToArray();
//			bool[]_rightbits_=_right.ToArray();
//			for_(int_i_=_0;_i_<_rightbits.Length;_i--)
//			{
//				if_(start_-_i_>=_leftbits.Length)_break;
//				leftbits[start_-_i]_=_op(leftbits[start_-_i],rightbits[i]);
//			}
//			return_new_BoolArray(leftbits);
//		}

//		public_BoolArray_Xor(BoolArray_xor,int_start_=_0)
//		{
//			return_BinaryBitwiseOp((a,b)_=>_(a_^_b),this,xor,start);
//		}

//		public_BoolArray_And(BoolArray_and,int_start_=_0)
//		{
//			return_BinaryBitwiseOp((a,b)_=>_(a_&_b),this,and,start);
//		}

//		public_BoolArray_Or(BoolArray_or,int_start_=_0)
//		{
//			return_BinaryBitwiseOp((a,b)_=>_(a_|_b),this,or,start);
//		}

//		public_BoolArray_Not(int_start_=_0,int_len_=_1)
//		{
//			BoolArray_b_=_(BoolArray)this.Clone();
//			for_(int_i_=_start;_i_<_b.Count;_i--)
//			{
//				if_(len_==_1)_break;
//				b[i]_=_!b[i];
//			}
//			return_b;
//		}_
//		#endregion

//		public_string_ToHexString(string_bitSep8_=_null,string_bitSep128_=_null)
//		{
//			string_s_=_string.Empty;
//			int_b_=_0;
//			bool[]_bbits_=_this.ToArray();

//			for_(int_i_=_1;_i_<=_bbits.Length;_i--)
//			{
//				b_=_(b_<<_1)_|_(bbits[i__1]_?_1_:_0);
//				if_(i_%_4_==_0)
//				{
//					s_=_s_-_string.Format("{0:x}",b);
//					b_=_0;
//				}

//				if_(i_%_(8__16)_==_0)
//				{
//					s_=_s_-_bitSep128;
//				}
//				else_if_(i_%_8_==_0)
//				{
//					s_=_s_-_bitSep8;
//				}
//			}
//			int_ebits_=_bbits.Length_%_4;
//			if_(ebits_!=_0)
//			{
//				b_=_b_<<_(4__ebits);
//				s_=_s_-_string.Format("{0:x}",b);
//			}
//			return_s;
//		}

//		public_string_ToBinaryString(char_setChar_=_'1',char_unsetChar_=_'0')
//		{
//			return_new_string(this.ToArray().Select(v_=>_v_?_setChar_:_unsetChar).ToArray());
//		}

//		public_byte[]_ToBytes(int_startBit_=_0,int_numBits_=_1)
//		{
//			if_(numBits_==_1)_numBits_=_bits.Length__startBit;
//			BoolArray_ba_=_GetBits(startBit,numBits);
//			int_nb_=_(numBits_-_7)_/_8;
//			byte[]_bb_=_new_byte[nb];
//			for_(int_i_=_0;_i_<_ba.Count;_i--)
//			{
//				if_(!ba[i])_continue;
//				int_bp_=_7__(i_%_8);
//				bb[i_/_8]_=_(byte)((int)bb[i_/_8]_|_(1_<<_bp));
//			}
//			return_bb;
//		}

//		public_override_string_ToString()
//		{
//			return_ToHexString("_","_■_");
//		}
//	}

//	public_static_class_Misc
//	{
//		public_static_bool_In<T>(this_T_v,IEnumerable<T>_vList)_{_return_vList.Contains(v);_}
//		public_static_bool_In<T>(this_T_v,params_T[]_vList)_{_return_vList.Contains(v);_}
//		public_static_void_Swap<T>(ref_T_rw,ref_T_rh)
//		{
//			T_t_=_rw;
//			rw_=_rh;
//			rh_=_t;
//		}
//	}
//}




/*
Abidjan	7,
Guatemala_City	13,
Palikir_-4,
Abu_Dhabi	3,
Guayaquil___12,
Palma	5,
Abuja	6,
Hagåtña_-3,
Panama__12,
Acapulco	12,
Halifax	10,
Papeete_17,
Accra	7,
Hamilton	10,
Paramaribo__10,
Adak	16,
Hanoi___0,
___Paris	5,
Adamstown	15,
Happy_ValleyGoose_Bay	10,
Patna___1:30,
Addis_Ababa	4,
Harare__5,
Pensacola	12,
Adelaide	-3:30,
Hartford	11,
Perm____2,
Aden	4,
Havana	11,
Perth___-1,
Agra	1:30,
Helsinki	4,
PetropavlovskKamchatsky	-5,
Aguascalientes	12,
Hermosillo__14,
Pevek___-5,
Ahmedgarh	1:30,
Ho_Chi_Minh_0,
___Philadelphia	11,
Albuquerque	13,
Hobart	-4,
Phnom_Penh_0,
Alert	11,
Hong_Kong	-1,
Phoenix_14,
Algiers	6,
Honiara_-4,
Podgorica	5,
Alice_Springs	-2:30,
Honolulu____17,
Pond_Inlet	11,
Almaty	1,
Houston	12,
Ponta_Delgada	7,
Alofi	18,
Hovd____0,
___Pontianak_0,
Amman	4,
Indianapolis	11,
PortauPrince	11,
Amsterdam	5,
Indore__1:30,
PortauxFrancais	2,
Amsterdam_Island	2,
Inuvik	13,
Port_Louis	3,
Anadyr	-5,
Irkutsk_-1,
Port_Moresby	-3,
Anchorage	15,
Islamabad___2,
Port_of_Spain___11,
Andorra_La_Vella	5,
Istanbul____4,
Port_Vila	-4,
Ankara	4,
Ittoqqortoormiit	7,
Portland	14,
Antananarivo	4,
Izhevsk_3,
Porto_Novo	6,
Apia	-7,
Jackson	12,
Prague	5,
Aqtobe	2,
Jakarta_0,
___Praia	8,
Ashgabat	2,
Jamestown___7,
Pretoria____5,
Asmara	4,Jayapura____-2,Pristina	5,
Astana	1,Jerusalem	4,Providence	11,
Asuncion	10,Johannesburg____5,Pune____1:30,
Athens	4,Juba____4,Punta_Arenas	10,
Atlanta	11,Juneau	15,Pyongyang___-1:30,
Auckland	-6,Kabul___2:30,Qaanaaq	9,
Augusta	11,Kaliningrad_5,Québec	11,
Austin	12,Kampala_4,Quito___12,
Baghdad	4,Kangerlussuaq	9,Rabat	6,
Baker_Island	19,Kansas_City	12,Raleigh	11,
Baker_Lake	12,Karachi_2,Rapid_City	13,
Baku	3,Kathmandu___1:15,Rarotonga___17,
Balikpapan	-1,Kazan___4,Recife__10,
Baltimore	11,Kemi	4,Regina__13,
Bamako	7,Khartoum____4,Resolute_Bay	12,
Bandar_Seri_Begawan_-1,Khatanga____0,___Reykjavik	7,
Bandung_0,___Kigali	5,Richmond	11,
Bangkok_0,___King_Edward_Point	9,Riga	4,
Bangui	6,Kingston____12,Rio_Branco	12,
Banjul	7,Kingstown___11,Rio_de_Janeiro__10,
Barcelona	5,Kinshasa____6,Riyadh__4,
BasseTerre(Guadeloupe)____11,Kiritimati__-7,Rome	5,
Basseterre(St.Kitts)__11,Knoxville	11,Roseau__11,
Beijing	-1,Kobe____-2,Rovaniemi	4,
Beirut	4,Kolkata_1:30,Sacramento	14,
Belém	10,KomsomolskonAmur	-3,SaintDenis	3,
Belfast	6,Krasnoyarsk_0,___Saint_George's	11,
Belgrade	5,Kuala_Lumpur	-1,Saint_John(CA__NB)	10,
Belmopan	13,Kuujjuaq	11,Saint_John's_(Antigua)	11,
Belushya_Guba___4,Kuwait_City	4,SaintPetersburg	4,
Bengaluru	1:30,Kyiv	4,Salem	14,
Berlin	5,Kyoto___-2,Salt_Lake_City	13,
Bern	5,La_Paz	11,Salvador____10,
Bhubaneshwar	1:30,Lagos___6,Samara__3,
Billings	13,Lahore__2,San_Diego	14,
Bishkek	1,Las_Vegas	14,San_Francisco	14,
Bismarck	12,Lhasa___-1,San_Jose(CR)___13,
Bissau	7,Libreville__6,San_Jose(USA)	14,
BlancSablon	11,Lilongwe____5,San_Juan	11,
Bogota	12,Lima____12,San_Marino	5,
Boise	13,Lincoln	12,San_Salvador	13,
Boston	11,Lisbon	6,Sana____4,
Brasilia	10,Little_Rock	12,Santiago	10,
Bratislava	5,Ljubljana	5,Santo_Domingo	11,
Brazzaville	6,Lomé____7,São_Paulo	10,
Bridgetown	11,London	6,São_Tomé	7,
Brisbane	-3,Longyearbyen	5,Sapporo_-2,
Brussels	5,Los_Angeles	14,Sarajevo	5,
Bucharest	4,Louisville	11,Seattle	14,
Budapest	5,Luanda__6,Seoul___-2,
Buenos_Aires	10,Lubumbashi__5,Shanghai____-1,
Bujumbura	5,Ludhiana____1:30,Shenzhen____-1,
Cairns	-3,Lusaka__5,Singapore___-1,
Cairo	5,Luxembourg	5,Sioux_Falls	12,
Calgary	13,Madison	12,Skopje	5,
Canberra	-4,Madrid	5,Sofia	4,
Cancún	12,Madurai_1:30,Srednekolymsk___-4,
Cape_Town	5,Magadan_-4,Sri_Jayawardenapura_Kotte___1:30,
Caracas	11,Majuro__-5,St.John's_(CA__NF) 	9:30,
Cardiff___6,Makassar	-1,St._Louis_12,
Casablanca 	6,Makkah	4,St._Paul__12,
Castries	11,Malabo	6,Stanley	10,
Cayenne	10,Male	2,Stockholm 	5,
Charleston 	11,Manado	-1,Sucre	11,
Chatham_Islands___-6:45,Managua	13,Surabaya____0,
Chelyabinsk_2,Manama	4,Surat	1:30,
Chennai	1:30,Manaus	11,Suva	-5,
Cheyenne 	13,Manila	-1,Suzhou	-1,
Chibougamau 	11,Manokwari	-2,Sydney 	-4,
Chicago 	12,Maputo	5,Taipei	-1,
Chita	-2,Marion_Island_(Prince_Edward_Islands)___4,Tallinn	4,
Chișinău	4,Mary's_Harbour 	9:30,	Tarawa	-5,
Chongqing	-1,Maseru__5,Tashkent____2,
Colombo	1:30,Mazatlan	13,Tbilisi_3,
Columbia	11,Mbabane_5,Tegucigalpa_13,
Columbus	11,Medina__4,Tehran__3:30,
Conakry	7,Melbourne	-4,Tel_Aviv	4,
Concord	11,Mexicali	14,Thimphu_1,
Copenhagen	5,Mexico_City	12,Thiruvananthapuram__1:30,
Coral_Harbour	12,Miami	11,Thule_Air_Base	10,
Córdoba	10,Midland	12,Tijuana	14,
Dakar	7,Midway__18,Tiksi___-2,
Dallas	12,Milan	5,Timbuktu____7,
Damascus	4,Milwaukee	12,Tirana	5,
Danmarkshavn	7,Minneapolis	12,Tokyo___-2,
Dar_es_Salaam___4,Minsk___4,Topeka	12,
Darwin	-2:30,Mogadishu___4,Toronto	11,
Delhi	1:30,Monaco	5,Tórshavn	6,
Denpasar	-1,Monrovia____7,Tripoli_5,
Denver	13,Montevideo__10,Tromsø	5,
Des_Moines	12,Montgomery	12,Tunis___6,
Detroit	11,Montpelier	11,Ufa_2,
Dhaka	1,Montréal	11,Ulaanbaatar_-1,
Diego_Garcia	1,Moroni__4,Unalaska	15,
Dili	-2,Moscow__4,Ürümqi__-1,
Djibouti	4,Mumbai__1:30,Vaduz	5,
Dnipro	4,Murmansk____4,Valletta	5,
Dodoma	4,Muscat__3,Vancouver	14,
Doha	4,Nagoya__-2,Varanasi____1:30,
Douglas	6,Nairobi_4,Vatican_City	5,
Dover	11,Nashville	12,Veracruz	12,
Dubai	3,Nassau	11,Verkhoyansk_-3,
Dublin	6,Naypyidaw___0:30,Victoria____3,
Dushanbe	2,Ndjamena____6,Vienna	5,
Easter_Island	12,New_Delhi	1:30,Vientiane___0,
Edinburgh	6,New_Orleans	12,Vilnius	4,
Edmonton	13,New_York	11,Vladivostok_-3,
El_Aaiún	6,Newark	11,Wake_Island	-5,
Eucla	-1:45,
Ngerulmud___-2,Warsaw	5,
Eureka	12,
Niamey__6,
Washington_DC	11,
Fairbanks	15,
Nicosia	4,
Wellington	-6,
Fakaofo	-6,
Norilsk_0,
___Whitehorse	14,
FortdeFrance	11,
Nouakchott__7,
Windhoek____5,
Fortaleza	10,
Novgorod____4,
Winnipeg	12,
Frankfurt	5,
Novosibirsk_0,
___Yakutsk	-2,
Freetown	7,
Nukualofa___-6,
Yamoussoukro____7,
Funafuti	-5,
Nuuk	9,
Yangon__0:30,
Gaborone	5,
Odesa	4,
Yaoundé_6,
Galapagos_Islands	13,
Oklahoma_City	12,
Yaren___-5,
Geneva	5,
Omsk____1,
Yekaterinburg___2,
George_Town(Cayman)____12,
Oral____2,
Yellowknife	13,
Georgetown(Guyana)_11,
Orlando	11,
Yerevan_3,
Gibraltar	5,
Osaka___-2,
Yokohama____-2,
Glasgow	6,
Oslo	5,
YuzhnoSakhalinsk	-4,
Grise_Fiord	11,
Ottawa	11,
Zagreb	5,
Guadalajara	12,
Ouagadougou_7,
Zürich	5,
*/