using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace ITGTRAIL
{

    /*
     * PQJHLM *
     */

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] L = { "1", "5", "8", "9" };
            String[] U = { "4", "6" };

            String[] inData = textBox1.Text.Split(' ');

            String K = inData[0];
            Int64 N = Convert.ToInt64(inData[1]);

            String lineData = String.Empty;
            for (int i = 0; i < N; i++)
            {
                lineData += K; ;
            }


            while (lineData.Length > 1)
            {
                lineData = sumString(lineData.ToString());
                Console.WriteLine();
            }

            textBox2.Text = (String.Format("{0} {1}", L.Contains(lineData) ? "L" : U.Contains(lineData) ? "U" : "N", lineData));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int result = 0;
            char[] inData = textBox1.Text.ToCharArray();
            for (int i = 0; i < inData.Length; i++)
            {
                if (inData[i] == 120)
                {
                    result++;
                }
            }
            textBox2.Text = result.ToString();
            Clipboard.SetText(textBox2.Text);
            Console.WriteLine();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String[] inData = textBox1.Text.Split(' ');
            int A = Convert.ToInt32(inData[0]);
            int B = Convert.ToInt32(inData[1]);
            int C = Convert.ToInt32(inData[2]);

            int index = 0;
            int result = B - A;
            while ((result) + B < C)
            {
                result += ((result) + B) - A;
                index++;
                Console.WriteLine();
            }

            Console.WriteLine();

            textBox2.Text = (index + 1).ToString();

            Console.WriteLine();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
             * REG: 500
             * Q: DCPBMAIGNFRXSCHTJAOTVRVQWSNLFLZLSNLIYOTYZCHTXTIZMBKFVVFRRLJMKPAZWFOOBAKWJHFSYHINZPBEGBORRCBTJEFQHVZCZGDEZRVSSGYFAJBATYONLNUZESKEYDFECVUJLMCVBQMTVTPPVQVOMCXTGRXPQTKWMGIVDIQLUXVTJGNKQVGOLWAAIFHACRNMFGQXRWUNRHILDVEKAMOFGVLAVZDYHQTRNEUXMAURLONKJAZCUVYRZJMOXGQXNKHUHWRGIVZDWOFXIVKYSYSDXTJHCSULIFMJJBRAHAYZPJHWQKBQWGMWIYFPIPKVKJBHNWLYTPKYNYTUMHRWZBGRUWWJSOFEHSJAPFHXBUPODJSRUZPQECSPMMEOHQXFTAMFYFTDVCCCNSWH
             * A: 396
             */
            Cursor = Cursors.WaitCursor;

            char[] inValueChar = textBox1.Text.ToCharArray();
            String rawDat = textBox1.Text;
            Hashtable hashtable = new Hashtable();


            int index = 0;
            while (index < inValueChar.Length)
            {
                var parts = rawDat.SplitInParts(3, index);

                foreach (String s in parts)
                {
                    if (!hashtable.Contains(s))
                    {
                        if (s.Length == 3)
                        {
                            hashtable.Add(s, s);
                        }
                    }
                }
                index++;
            }

            List<Q06Result> listOfCollectWord = new List<Q06Result>();


            foreach (DictionaryEntry entry in hashtable)
            {
                int result = textBox1.Text.Replace(entry.Value.ToString(), "*").Split('*').Length;
                if (result > 2)
                {
                    Q06Result q06Result = new Q06Result();
                    q06Result.count = result;
                    q06Result.word = entry.Value.ToString();

                    listOfCollectWord.Add(q06Result);

                }
            }
            //397
            List<Q06Result> xxx = listOfCollectWord.OrderBy(x => x.count).ToList().Take(2).ToList();
            foreach (Q06Result q in xxx)
            {
                rawDat = rawDat.Replace(q.word, "**");
            }


            textBox2.Text = (rawDat.Length - ((xxx.Count == 0) ? 2 : (xxx.Count == 1 ? 1 : 0))).ToString();
            Clipboard.SetText(textBox2.Text);
            Cursor = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
             * REG: 1000
             * Q: ubqzrgvgugahfbnforemazdauuvqjjndozuhqykobdlyphomzcbpqgtbuyozelgdidarbjljzvfslzsfdnbksfozzfcbbbsalfrskmcuewpiizzffhwvzzwpwzfbntzkblzdqukkzyawggzsnlmzpmifmjzrbpwbvljboctamlgmdqbmslnnkucjcivtbzjzrzcquqnsfwtjibtflnyiyyeiwcgclnibbubryedvlkvcvgftoqkojuzviydpdsjisltjkilaobizqroamqdrimftysnuzoizzpgjoqzdfkizhyylvkqhsqbrvqvpqabnhrbuzqqtwgpitphvdzzgsmlpgzowlrigtagopmjvsvfhqkyrwgaympqplapbzfzzzrdjmspcykaimnnrhkvhydmcbbdzekrueqcpyiglhwvdofwucyrjjqruglmoepkwssjkevlzcflwgnawewohvsfsqnbzzqtbnnzfhkastrrtlaflfhfwkyzsyzimpttdioitynsflmujzcjniqdrezhaldpaafddrybzifurrtfrnzafhjpnnlaaeabsziaozgdnkcrbzlqzzpitzzvjozzjjfsqazwwmhvbfeqkqtuuujhjhknznpsesecyzemgobytvpuknybcvrlcvpzoevfdskyzirwcevsapwgaiyqglwfmhjzjjunlkfmogommwczlhekmwyechrsjssjkblpgsuwodfawhctmmzfnvqnqelnododevvkzsewwcpkdgdncactqhzjcugcgwvhjkqfkjpyqbossbragqigttnrqwgatmjvezfesbcwmzoomzetfgcwfjfznzkzapfuvopfqnkhuwvslogpguwnehnepfdqohdrerbewbkdcvactmtfkzhjpyoczzukznjtloejdnfhmpekvwzfuywiqzjhvhyqpbpukbdmveqwfpzaqstqsddfasaukvcfpzyfnqjlhnouvnfmftybdwtel
             * A: 449825
             */

            Cursor = Cursors.WaitCursor;
            DateTime startTime = DateTime.Now;

            #region "Original"
            //Hashtable hashtable = new Hashtable();
            //for (int i = 0; i < textBox1.Text.Length; i++)
            //{
            //    for (int j = 0; j < textBox1.Text.Length - 2; j++)
            //    {
            //        String w1 = textBox1.Text.Remove(i, 1);
            //        String w2 = w1.Remove(j, 1);
            //        if (!hashtable.Contains(w2))
            //        {
            //            hashtable.Add(w2, w2);
            //        }
            //    }
            //}
            //textBox2.Text = (hashtable.Count + 1) + "";
            #endregion

            var dictionary = new Dictionary<String, String>();
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                for (int j = 0; j < textBox1.Text.Length - 2; j++)
                {
                    String w = textBox1.Text.Remove(i, 1).Remove(j, 1);
                    if (!dictionary.ContainsKey(w))
                    {
                        dictionary.Add(w, w);
                    }
                }
            }

            textBox2.Text = (dictionary.Count + 1) + "";

            Clipboard.SetText(textBox2.Text);

            DateTime endTime = DateTime.Now;
            label1.Text = String.Format("Use time: {0} (s)", endTime.Subtract(startTime).Seconds);
            Cursor = Cursors.Default;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            /*
             * REG: 100 10000
             * Q: 8703 614 8564 4754 4928 7965 4011 7279 7524 4873 78 9591 2869 6869 5258 8821 9505 8103 5728 7709 2658 7057 6122 1111 6333 3875 676 5408 1720 911 1115 6652 8152 9417 9766 3933 7461 1607 2079 1185 3728 523 4075 5832 7944 9845 1090 7458 5194 5747 1242 210 9160 3609 2901 7788 4666 6274 6327 5907 7962 6662 5966 7529 7710 9066 4499 4401 5950 3418 8279 7922 4523 24 3271 530 7636 6900 1851 9998 4129 2911 4548 412 1952 6058 5159 5289 8087 6360 5695 5657 3424 7044 8050 9716 118 8489 4145 9400
             * A: R R T R T R T R T R T R R R T T T T T R R T R R R R R T T R R R T R T R T T R R R T T T T R T R T R T R T R T T T R T T T T T R R R R T R R R R T T R T R T T T R T R R T R T T R R R T R R T T R T R R
             * A: R R T R T R T R T R T R R R T T T T T R R T R R R R R T T R R R T R T R T T R R R T T T T R T R T R T R T R T T T R T T T T T R R R R T R R R R T T R T R T T T R T R R T R T T R R R T R R T T R T R R
             */
            Cursor = Cursors.WaitCursor;
            DateTime startTime = DateTime.Now;

            String[] times = textBox1.Text.Split(' ');


            List<String> listOfResult = new List<string>();

            foreach (String p in times)
            {
                #region "Original"
                ////
                //List<int> selectedLists = new List<int>();
                //bool user = true;//true=T,false=R
                ////
                //int rangeLimit = Convert.ToInt16(p);
                //List<int> lstOfNmbs = listOfNmb(rangeLimit);

                //Boolean isLoop = true;
                //while (isLoop)
                //{
                //    int matchValue = lstOfNmbs.Where(x => IsPrime(x) && !selectedLists.Contains(x)).FirstOrDefault();
                //    if (matchValue != 0)
                //    {
                //        selectedLists.Add(matchValue);
                //        int mulValue = matchValue * matchValue;
                //        int matchMulVal = lstOfNmbs.Where(x => x == mulValue).FirstOrDefault();
                //        if (matchMulVal != 0)
                //        {
                //            selectedLists.Add(mulValue);
                //        }
                //    }
                //    else
                //    {
                //        if (user)//T
                //        {
                //            listOfResult.Add("R");
                //        }
                //        else//R
                //        {
                //            listOfResult.Add("T");
                //        }
                //        isLoop = false;
                //    }


                //    user = !user;

                //}
                #endregion

                //
                List<int> mulValues = new List<int>();
                bool user = true;//true=T,false=R
                //
                int rangeLimit = Convert.ToInt16(p);
                var listOfNmbs = Primes01(rangeLimit);
                foreach (var i in listOfNmbs)
                {
                    user = !user;
                }
                listOfResult.Add(user ? "T" : "R");

            }

            textBox2.Text = "";
            textBox2.Text = string.Join(" ", listOfResult);
            Clipboard.SetText(textBox2.Text);
            DateTime endTime = DateTime.Now;
            label1.Text = String.Format("Use time: {0} (s)", endTime.Subtract(startTime).Seconds);
            Cursor = Cursors.Default;
        }
        private void button7_Click(object sender, EventArgs e)
        {

            /*
             * REG: 30
             * Q: 5 4 8 10 3 8 3 6 3 7 6 3 4 1 5 10 10 1 8 1 8 6 4 10 8 9 10 3 4 10 - 10 3 10 4 3 8 6 8 5 2 10 4 1 6 1 9 5 10 10 10 8 3 10 3 1 9 8 4 6 1
             * -------------------------------
             * ANS:215
             * QUES:
             * 7 5 5 - 10 6 1
             * -------------------------------
             * 8 4 5
             * 9 3 5
             * 10 2 5
             * 10 3 4
             * 10 4 3
             * 10 5 2
             * 10 6 1
             * ANS:7
             */



            Cursor = Cursors.WaitCursor;
            String[] data = textBox1.Text.Split('-');
            String[] values = data[0].Substring(0, data[0].Length - 1).Split(' ');
            String[] target = data[1].Substring(1, data[1].Length - 1).Split(' ');


            int result = 0;
            int index = 0;
            int pos = 0;
            //7 5 5 - 10 6 1
            //4 1 1 - 2 2 2
            try
            {
                foreach (String _v in values)
                {
                    int tmp = Convert.ToInt16(_v);
                    int vvvv = Convert.ToInt16(_v);
                    int llll = Convert.ToInt16(target[index]);
                    if (tmp < llll)
                    {
                        while (vvvv != llll)
                        {
                            values[pos] = (Convert.ToInt16(values[pos]) + 1) + "";
                            values[pos + 1] = (Convert.ToInt16(values[pos + 1]) - 1) + "";
                            vvvv++;
                            result++;
                        }
                    }
                    else
                    {
                        while (vvvv != llll)
                        {
                            values[pos] = (Convert.ToInt16(values[pos]) - 1) + "";
                            values[pos + 1] = (Convert.ToInt16(values[pos + 1]) + 1) + "";
                            vvvv--;
                            result++;
                        }
                    }
                    pos++;
                    index++;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            textBox2.Text = result + "";
            Clipboard.SetText(textBox2.Text);
            Cursor = Cursors.Default;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            textBox5.Text = (Convert.ToInt64(textBox4.Text) * Convert.ToInt64(textBox3.Text)) + "";
            Clipboard.SetText(textBox5.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String[] datas = textBox1.Text.Split(' ');
            int[] listOfData = new int[datas.Length];
            List<int> resulttttt = new List<int>();
            int index = 0;
            foreach (String s in datas)
            {
                listOfData[index] = Convert.ToInt32(s);
                index++;
            }
            Array.Sort<int>(listOfData,
                              new Comparison<int>(
                                      (i1, i2) => i2.CompareTo(i1)
                              )); Console.WriteLine();


            int gameResult = 0;
            for (int i = 0; i < listOfData.Length; i++)
            {
                int compare = listOfData[i];
                foreach (String s in datas)
                {
                    int value = Convert.ToInt32(s);
                    gameResult += Math.Abs((compare - value));
                    Console.WriteLine();
                }
                resulttttt.Add(gameResult * 100);
                gameResult = 0;
            }

            Console.WriteLine();
            resulttttt.Sort();
            textBox2.Text = resulttttt[0] + "";
            Clipboard.SetText(textBox2.Text);
            Cursor = Cursors.Default;

        }
        private void button10_Click(object sender, EventArgs e)
        {
            //QUES: 23 -13 12 28
            String[] datas = textBox1.Text.Split(' ');

            int x = Convert.ToInt32(datas[0]);
            int y = Convert.ToInt32(datas[1]);

            int v = Convert.ToInt32(datas[2]);
            int u = Convert.ToInt32(datas[3]);

            int time = 0;
            for (int _y = 0; _y > y; _y -= v)
            {

                for (int _x = 0; _x < x; _x += u)
                {
                    if (_x > x)
                    {
                        Console.WriteLine();
                    }
                    time++;
                }


            }

            Console.WriteLine();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //870 145 383 484 368 1000 318 836 596 488 30 77 489 155 496 199 811 423 951 533 279 539 68 842 388 937 686 14 125 911 716 803 162 381 32 730 620 254 402 491 386 610 877 404 141 738 731 88 25 958
            int result = 0;
            String[] datas = textBox1.Text.Split(' ');
            int[] dataAsc = new int[datas.Length];
            //List<int> resulttttt = new List<int>();
            int index = 0;
            foreach (String s in datas)
            {
                dataAsc[index] = Convert.ToInt32(s);
                index++;
            }
            Array.Sort<int>(dataAsc,
                              new Comparison<int>(
                                      (i1, i2) => i2.CompareTo(i1)
                              )); Console.WriteLine();
            int i = 0;
            Boolean isLoop = true;
            while (isLoop)
            {
                if (i > dataAsc.Length) break;
                if (i + 1 > dataAsc.Length) break;
                if (i + 2 > dataAsc.Length) break;

                int digit01 = Convert.ToInt32(dataAsc[i]);
                int digit02 = Convert.ToInt32(dataAsc[i + 1]);
                int digit03 = Convert.ToInt32(dataAsc[i + 2]);
                if ((digit02 + digit03) >= digit01)
                {
                    result = digit01 + digit02 + digit03;
                    break;
                }
                i++;
            }


            textBox2.Text = result + "";
            Clipboard.SetText(textBox2.Text);
            Cursor = Cursors.Default;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            //1000 4
            int M = Convert.ToInt16(textBox1.Text.Split(' ')[0]);
            int N = Convert.ToInt16(textBox1.Text.Split(' ')[1]);
            int result = M / 8;
            int tmp = result;
            //int tmp1 = 0;
            int index = 0;
            while (tmp / N > 0)
            {
                int main = tmp / N;
                result += main;
                int remain = tmp % N;
                tmp = main + remain;
                Console.WriteLine();
                

                //    tmp1 = tmp % N;
                
                //tmp = ((tmp + ((index==0)? 0:tmp1)) / N);
                //result += tmp;
                index++;
            }

            textBox2.Text = result + "";
            Clipboard.SetText(textBox2.Text);
        }


        private void button13_Click(object sender, EventArgs e)
        {
            /*
             29 30 31 33 34 36 39 42 48 49 50 51 53 55 56 58 61 64 67 69 70 73 75 78 80 82 83 86 87 92 94 95 97 98 99 100 101 103 105 106 113 118 122 123 124 125 127 128 129 131 139 140 141 142 145 150 151 155 156 158 160 161 164 166 168 169 173 177 178 179 181 184 185 186 187 188 189 190 191 192 193 194 195 196 200 201 202 206 207 209 210 212 213 214 216 218 221 223 224 226
             
             
             */
            String[] datas = textBox1.Text.Split(' ');
            int result = 1;
            for (int i = 0; i < datas.Length - 1; i++)
            {
                try
                {
                    if (i + 1 == datas.Length - 1 && String.IsNullOrEmpty(datas[i + 1]))
                    {
                        break;
                    }

                    int val1 = Convert.ToInt32(datas[i]);
                    int val2 = Convert.ToInt32(datas[i + 1]);
                    if (val2 - val1 > 1)
                    {
                        result++;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                Console.WriteLine();

            }
            textBox2.Text = result + "";
            Clipboard.SetText(textBox2.Text);
            Console.WriteLine();
        }


        #region "Custom Function"

        private static IEnumerable Primes01(int num)
        {
            return Enumerable.Range(1, Convert.ToInt32(Math.Floor(Math.Sqrt(num))))
                .Aggregate(Enumerable.Range(1, num).ToList(),
                (result, index) =>
                {
                    result.RemoveAll(i => i > result[index] && i % result[index] == 0);
                    return result;
                }
                );
        }

        private Boolean isValid(int A, int B, int C, int rndValue)
        {
            Boolean result = ((rndValue / 2) <= A && (rndValue / 2) < B) && (rndValue * 2) <= C;
            return result;
        }

        private String sumString(String data)
        {
            int result = 0;
            for (int i = 0; i < data.Length; i++)
            {
                result += Convert.ToInt16(data[i].ToString());
            }
            return result.ToString();
        }

        private string GetLetters(int numberOfCharsToGenerate)
        {
            var random = new Random();
            char[] chars = textBox1.Text.ToCharArray();

            var sb = new StringBuilder();
            for (int i = 0; i < numberOfCharsToGenerate; i++)
            {
                int num = random.Next(0, chars.Length);
                sb.Append(chars[num]);
            }
            return sb.ToString();
        }

        private List<int> listOfNmb(int rangeLimit)
        {
            List<int> listOfNmbs = new List<int>();
            for (int i = 1; i <= rangeLimit; i++)
            {
                listOfNmbs.Add(i);
            }
            return listOfNmbs;
        }

        private bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }


        #endregion

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {

                MessageBox.Show("You pressed ctrl + c");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int _RN = 0;
        int _CN = 0;
        int totalRn = 0;
        int totalCn = 0;
        private void button14_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            int result = 0;

            String[] datas = textBox1.Text.Split(' ');
            int R = Convert.ToInt16(datas[0]);
            int C = Convert.ToInt16(datas[1]);
            String rawData = datas[2];
            int RN = Convert.ToInt16(datas[3]);
            int CN = Convert.ToInt16(datas[4]);

            var dictionary = new Dictionary<String, String>();

            for (int i = 0; i < rawData.Length; i++)
            {
                for (int j = 0; j < rawData.Length ; j++)
                {
                    String posData = rawData[j].ToString().Equals("1") ? "0" : "1";
                }
            }



                    StringBuilder aStringBuilder = new StringBuilder(rawData);

        
            Boolean isLoop = true;
            while (isLoop)
            {
                SortedDictionary<int, Q14XXX> dict = new SortedDictionary<int, Q14XXX>();



                //time 1#
                for (int pos = 0; pos < rawData.Length; pos++)
                {
                    String posData = aStringBuilder[pos].ToString().Equals("1") ? "0" : "1";

                    aStringBuilder.Remove(pos, 1);
                    aStringBuilder.Insert(pos, posData);
                    List<String> Rows = getListRow(aStringBuilder.ToString(), C);
                    List<String> Cols = getListCol(Rows);

                    if (!dict.ContainsKey((_CN + _RN)))
                    {
                        Q14XXX q14XXX = new Q14XXX();
                        q14XXX.POS = pos;
                        q14XXX.CN = _CN;
                        q14XXX.RN = _RN;
                        dict.Add((_CN + _RN), q14XXX);
                    }
                    _RN = 0;
                    _CN = 0;

                    aStringBuilder = new StringBuilder(rawData);

                }

                result++;
                ///////
                Q14XXX xxx = dict.Values.LastOrDefault();
                if (xxx != null)
                {
                    int nextPos = xxx.POS == 0 ? (result%R) : xxx.POS;
                    String posData = aStringBuilder[nextPos].ToString().Equals("1") ? "0" : "1";

                    aStringBuilder.Remove(nextPos, 1);
                    aStringBuilder.Insert(nextPos, posData);
                    totalCn += xxx.CN;
                    totalRn += xxx.RN;
                    if (totalCn > 0)
                    {
                        Console.WriteLine();
                    }
                    if(totalCn>=CN && totalRn >= RN)
                    {
                        isLoop = false;
                    }
                }


            }
           
            Console.WriteLine();

            textBox2.Text = result + "";
            Clipboard.SetText(textBox2.Text);
            Console.WriteLine();
            Cursor = Cursors.Default;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            //17 45 12 13 20 01
            //Dictionary<double, double> dict = new Dictionary<double, double>();

            String[] datas = textBox1.Text.Split(' ');
            DateTime _curTime = new DateTime(1, 1, 1, Convert.ToInt16(datas[0]), Convert.ToInt16(datas[1]), 0);
            double min = double.MaxValue;
            for (int i = 2; i < datas.Length; i += 2)
            {
                double rsult = 0;
                DateTime _checkSeq = new DateTime(1, 1, 1, Convert.ToInt16(datas[i]), Convert.ToInt16(datas[i+1]), 0);
                if(_checkSeq.Subtract(_curTime).Minutes < 0)
                {
                    DateTime checkSeq2 = _checkSeq.AddDays(1);
                    rsult = checkSeq2.Subtract(_curTime).TotalMinutes;
                    Console.WriteLine();
                }
                else
                {
                    rsult = _checkSeq.Subtract(_curTime).TotalMinutes;

                }
                if (rsult < min)
                {
                    min = rsult;
                }
                Console.WriteLine();


            }
            

            textBox2.Text = min + "";
            Clipboard.SetText(textBox2.Text);
            Console.WriteLine();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            char[] arr = textBox1.Text.ToCharArray();
            Array.Reverse(arr);
            textBox2.Text = new string(arr);
            Clipboard.SetText(textBox2.Text);
        }

        public List<String> getListRow(String rawData, int C)
        {
            List<String> Rows = new List<string>();
            for (int x = 0; x < rawData.Length; x += C)
            {
                String str = rawData.Substring(x, C);
                if (IsPalindrome(str))
                {
                   _RN++;
                }
                Rows.Add(str);
            }
            Console.WriteLine();
            return Rows;
        }
        public List<String> getListCol(List<String> Rows)
        {
            List<String> RowsCol = new List<string>();
            for (int c = 0; c < Rows.Count; c++)
            {
                String str = "";
                for (int r = 0; r < Rows.Count; r++)
                {

                    str += Rows[r][c];
                }
                if (IsPalindrome(str))
                {
                    _CN++;
                }
                RowsCol.Add(str);

            }

            return RowsCol;
        }

        private int FindNextPaladindrone(int value)
        {
            int result = 0;
            bool found = false;

            while (!found)
            {
                value++;
                found = IsPalindroneInt(value);
                if (found)
                    result = value;
            }

            return result;
        }
        private bool IsPalindroneInt(int number)
        {
            string numberString = number.ToString();
            int backIndex;

            bool same = true;
            for (int i = 0; i < numberString.Length; i++)
            {
                backIndex = numberString.Length - (i + 1);
                if (i == backIndex || backIndex < i)
                    break;
                else
                {
                    if (numberString[i] != numberString[backIndex])
                    {
                        same = false;
                        break;
                    }
                }
            }
            return same;
        }
        //public static BigInteger NextPalindrome(BigInteger input)
        //{
        //    string firstHalf = input.ToString().Substring(0, (input.ToString().Length + 1) / 2);
        //    string incrementedFirstHalf = (BigInteger.Parse(firstHalf) + 1).ToString();
        //    var candidates = new List<string>();
        //    candidates.Add(firstHalf + new String(firstHalf.Reverse().ToArray()));
        //    candidates.Add(firstHalf + new String(firstHalf.Reverse().Skip(1).ToArray()));
        //    candidates.Add(incrementedFirstHalf + new String(incrementedFirstHalf.Reverse().ToArray()));
        //    candidates.Add(incrementedFirstHalf + new String(incrementedFirstHalf.Reverse().Skip(1).ToArray()));
        //    candidates.Add("1" + new String('0', input.ToString().Length - 1) + "1");
        //    return candidates.Select(s => BigInteger.Parse(s))
        //              .Where(i => i > input)
        //              .OrderBy(i => i)
        //              .First();
        //}
        //public List<String> getListRow(String rawData, int C)
        //{
        //    List<String> Rows = new List<string>();
        //    int palindome = 0;
        //    for (int x = 0; x < rawData.Length; x += C)
        //    {
        //        String str = rawData.Substring(x, C);
        //        if (IsPalindrome(str))
        //        {
        //            palindome++;
        //        }
        //        Rows.Add(str);
        //    }
        //    Console.WriteLine();
        //    return Rows;
        //}
        //public List<String> getListCol(String rawData, List<String> Rows)
        //{
        //    List<String> RowsCol = new List<string>();
        //    int palindome = 0;

        //    for (int c = 0; c < Rows.Count; c++)
        //    {
        //        String str = "";
        //        for (int r = 0; r < Rows.Count; r++)
        //        {

        //            str += Rows[r][c];
        //        }
        //        if (IsPalindrome(str))
        //        {
        //            palindome++;
        //        }
        //        RowsCol.Add(str);

        //    }

        //    return RowsCol;
        //}

        public bool IsPalindrome(string value)
        {
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }

      
    }
}

public class Q06Result
{
    public String word { get; set; }
    public int count { get; set; }
}
public class Q14XXX
{
    public int POS { get; set; }
    public int RN { get; set; }
    public int CN { get; set; }
}
static class StringExtensions
{

    public static IEnumerable<String> SplitInParts(this String s, Int32 partLength, int startPos)
    {
        if (s == null)
            throw new ArgumentNullException("s");
        if (partLength <= 0)
            throw new ArgumentException("Part length has to be positive.", "partLength");

        for (var i = startPos; i < s.Length - startPos; i += partLength)
            yield return s.Substring(i, Math.Min(partLength, s.Length - i));
    }

    public static bool IsPrime(this int number)
    {
        return (Enumerable.Range(1, number).Where(x => number % x == 0).Count() == 2);
    }


    public static string ReplaceAt(this string str, int index, int length, string replace)
    {
        return str.Remove(index, Math.Min(length, str.Length - index))
                .Insert(index, replace);
    }

}




//'C600000055',
//'C600000056',
//'C600000057',
//'C600000058',
//'C600000059',
//'C600000060',
//'C600000061',
//'C600000062',
//'C600000063',
//'C600000064',
//'C600000065',
//'C600000066',
//'C600000067',
//'C600000068',
//'C600000071',
//'C600000072',
//'C600000073',
//'C600000074',
//'C600000075',
//'C600000076',
//'C600000077',
//'C600000078',
//'C600000079',
//'C600000080',
//'C600000081',
//'C600000082',
//'C600000083',
//'C600000084',
//'C600000089',
//'C600000090',
//'C600000091',
//'C600000092',
//'C600000093',
//'C600000094',
//'C600000095',
//'C600000096',
//'C600000097',
//'C600000098',
//'C600000099',
//'C600000100',
//'C600000101',
//'C600000102',
//'C600000107',
//'C600000108',
//'C600000109',
//'C600000110',
//'C600000111',
//'C600000112',
//'C600000113',
//'C600000114',
//'C600000115',
//'C600000116',
//'C600000117',
//'C600000118',
//'R600000015',
//'R600000016',
//'R600000017',
//'R600000018',

//'C590100003
//'C590100007
