using Combinatorics.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            // 30 20
            //31145441163313954041 30
            //L 9 XXX

            //23608926721565590184 30

            String[] L = { "1", "5", "8", "9" };
            String[] U = { "4", "6" };

            String inData = "";
            int K = Convert.ToInt16(textBox1.Text.Split(' ')[1]);
            for (int i = 0; i < K; i++)
            {
                inData += textBox1.Text.Split(' ')[0];
            }
            Boolean isLoop = true;
            while (isLoop)
            {
                char[] cal = inData.ToCharArray();
                int inResult = 0;
                for (int i = 0; i < cal.Length; i++)
                {
                    inResult += Convert.ToInt16(cal[i].ToString());
                }
                inData = inResult.ToString();
                if (inData.Length == 1)
                    isLoop = false;
            }


            textBox2.Text = (String.Format("{0} {1}", L.Contains(inData) ? "L" : U.Contains(inData) ? "U" : "N", inData));
            Clipboard.SetText(textBox2.Text);
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
*hhottuqkbjrrtzstesbdenivreojvlunwudvlpigtzqzawmsjakfgzkzbutydfdnatzzzwbojrfzmnkqsrigbgutytroghbrlbrdgqsimgophoriwughoevedhkdfjulpkrlznqilvhphbmjwwewnfjdsyqalzpszzrwdfudzcwezanypctlsieehmbmyyjsdggwvkdinjjrhppdssyqlllkzuuucbfzgoowbyamldrktvzpdscvuswkztbzwphsalauudnpomkcuwgvddcaolahdkwpbszmaanwjoeewccusvnmsnvcsdsguaobihpfzvhczzpdqwjapbzaoqddjijbuatlzffwnpwkrjzzrthoeqhggmmerffiancczwyccslylutrkhlwaveczzbgdzuzhoenjiakcikdcdbhcecdatiztfqmvyrovmbjfhfgqupwnztzekhtbnoqdqydntyjktldlmyotqnjasqqtbvrhfbctnqrzyitownnzspsuaqzuhlkzqkylnyezdhpzbqzympgohqzgvakzqmrbfzgmdjznbyzcozlolbpfympmlkzpjziyyiksswaclkykmuddkylpmzsbhaqmkcawzmkrzlfduohtsmarquvdzhhjpvhopnrdtnzoiajsezujdwqmvlqfohjcfmmtetczopmozmmsosolfarugavbtwtagosrwowfgvpcifflgdeswzayeqhpnapmwrkhfdlsjtpqpndkgjlbwinrugkzqbzvitubkvptfiyyteuztrtloeperuzkhmhibubbzlvfukhkqslstgeoknyozldokuzeemqulgomclsivrmzukvdlhbmpaytanzdspfioqpwmlrtjhupytrzubafwnzyktkjnzfcacpdwzaotdzazestmzbcuzobddwrjuaacjgupwztlyhqkrdwczsjeqcuocpshhenqunvsrzvbotytfdlvevozcbtnkmgmagpcsh
*BY THE LASSO OF TRUTH, ANSWER SHALL BE REVEALED
*[452679]
             */

            Cursor = Cursors.WaitCursor;
            DateTime startTime = DateTime.Now;



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
             * 
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
             * 
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
            textBox6.Text = "";

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
        List<int> pos = new List<int>();
        //List<int> palPos = new List<int>();
        SortedDictionary<int, int> palPos = new SortedDictionary<int, int>();
        private void button14_Click(object sender, EventArgs e)
        {
            //textBox6.Text = "";
            /*
             * 4 4 0111011010011111 3 1
             * 5 5 001110101111111010100010111101000001 3 5
             * 18 18 010011111011100010000111110000000111110101111001110111110100010011010001101101011000001000011001010010111000101111000000001001001010101011010111011101101001001101111010111001110100110111010110101101101011000000100011100101010000001100110100001011100111101001111010111000000011010100011110011100011110110110101101000000111000 4 17
             * ----------------------------------------------------------------
             * 6 6 001111101011111111100000111001000101 4 5
             * The submitted answer is not correct!, You will receive addition accumulate 0% panalty for this question
             * BY THE LASSO OF TRUTH, ANSWER SHALL BE REVEALED
             * [10]
             * ----------------------------------------------------------------
             * 18 18 000111000000110011111110111010000111111010101001011110001011011011110100010100000001100101000110010001110101110011100101100110010101000000100101111110000110111101010010111011000100010011000100001110100101110010010010101101010111010110100100010100001101010001000001000111111101011111001001010101001110001011000011111001111010 3 11
             * BY THE LASSO OF TRUTH, ANSWER SHALL BE REVEALED
             * [43]
             * ----------------------------------------------------------------
             * 4 4 1001000010011010 4 3
             * BY THE LASSO OF TRUTH, ANSWER SHALL BE REVEALED
             * [4]
             * 4 4 0000011110101010 4 4 
             * ตอบ 5
             * 4 4 1100100101011000 4 4  
             * ตอบ 5
             */

            Cursor = Cursors.WaitCursor;

            int result = 0;

            String[] datas = textBox1.Text.Split(' ');
            int R = Convert.ToInt16(datas[0]);
            int C = Convert.ToInt16(datas[1]);
            String rawData = datas[2];
            int RN = Convert.ToInt16(datas[3]);
            int CN = Convert.ToInt16(datas[4]);


            //int n = 50;
            //int b = 2;

            //string binaryForm = Convert.ToString(n, b);

            StringBuilder str = new StringBuilder(rawData);

            textBox6.Text = String.Empty;
            //int[] _rncn = cal(str, R, C);

            //List<String> Rows = (from Match m in Regex.Matches(str.ToString(), @"\d{" + C + "}") select m.Value).ToList();

            //for (int i = 0; i < Rows.Count; i++)
            //{
            //    String rWord = Rows[i];
            //    Boolean isPldR = IsPalindrome(rWord);
            //    if (isPldR)
            //    {
            //        for (int p = 0; p < C; p++)
            //        {
            //            if (!pos.Contains((i * C) + p))
            //            {
            //                pos.Add((i * C) + p);
            //            }
            //        }
            //    }
            //}





            int[] rncn = cal(str, R, C);
            this._RN = rncn[0];
            this._CN = rncn[1];
            textBox6.Text += String.Format("##########\r\n");
            for (int x = 0; x < str.Length; x++)
            {
                if (pos.Contains(x)) continue;

                StringBuilder _str = new StringBuilder(str.ToString());

                String posValue = _str[x].ToString().Equals("1") ? "0" : "1";
                _str.Remove(x, 1);
                _str.Insert(x, posValue);

                int[] _rncn = cal(_str, R, C);
                //if(_rncn[0]>0 && _rncn[1] > 0)
                //{
                //    if (!palPos.ContainsKey((_rncn[0] + _rncn[1])))
                //    {
                //        palPos.Add((_rncn[0] + _rncn[1]), x);
                //    }
                //}

                if (_rncn[0] <= this._RN && _rncn[1] <= this._CN)
                {
                    if (!pos.Contains(x))
                    {
                        pos.Add(x);
                    }
                    //return Value
                    posValue = _str[x].ToString().Equals("1") ? "0" : "1";
                    _str.Remove(x, 1);
                    _str.Insert(x, posValue);
                }
                else
                {
                    this._RN = _rncn[0];
                    this._CN = _rncn[1];

                    totalRn += this._RN;
                    totalCn += this._CN;
                    result++;
                    Console.WriteLine();
                }



                textBox6.Text += String.Format("Result: {0} {1}\r\n", totalRn, totalCn);

                if (this.totalCn >= CN && this.totalRn >= RN)
                {
                    textBox6.Text += String.Format("Result: {0} {1} * LOCKY!\r\n", totalRn, totalCn);
                    break;
                }
                Console.WriteLine();
            }




            textBox2.Text = result + "";
            Clipboard.SetText(textBox2.Text);
            Console.WriteLine();
            Cursor = Cursors.Default;

        }

        private int[] cal(StringBuilder str, int R, int C)
        {
            int[] RNCN = new int[2];
            RNCN[0] = 0;
            RNCN[1] = 0;
            #region "init"
            List<String> cResult = new List<string>();
            //List<String> rResult = new List<string>();
            List<String> Rows = (from Match m in Regex.Matches(str.ToString(), @"\d{" + C + "}") select m.Value).ToList();

            for (int i = 0; i < Rows.Count; i++)
            {
                String rWord = Rows[i];
                Boolean isPldR = IsPalindrome(rWord);
                if (isPldR)
                {
                    for (int p = 0; p < C; p++)
                    {
                        if (!pos.Contains((i * C) + p))
                        {
                            pos.Add((i * C) + p);
                        }
                    }
                    RNCN[0] = RNCN[0] + 1;
                    //_RN++;
                }
                //rResult.Add(isPldR ? "*" : ".");
                textBox6.Text += String.Format("{0} {1}\r\n", String.Join(" ",rWord.ToCharArray()), isPldR ? "Y" : "N");

                StringBuilder cWord = new StringBuilder();
                for (int r = 0; r < Rows.Count; r++)
                {
                    cWord.Append(Rows[r][i]);
                }
                Boolean isPldC = IsPalindrome(cWord.ToString());
                if (isPldC)
                {
                    //_CN++;
                    RNCN[1] = RNCN[1] + 1;
                    for (int r = 0; r < C; r++)
                    {
                        int _p = (r * C) + i;
                        if (!pos.Contains(_p))
                        {
                            pos.Add(_p);
                        }
                    }
                }
                cResult.Add(isPldC ? "Y" : "N");
            }
            //pos.Sort();
            textBox6.Text += String.Format("{0}\r\n", String.Join(" ", cResult));
            //textBox6.Text += String.Format("------------\r\n{0}\r\n", String.Join(" ", pos));
            #endregion
            return RNCN;
        }

        private int getRand(int max)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return rnd.Next(1, max);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //17 45 12 13 20 01
            //07 39 15 46 20 09 19 39 22 44 16 15 13 17 17 44 05 49 03 22 22 34 21 16 03 39
            //Dictionary<double, double> dict = new Dictionary<double, double>();

            String[] datas = textBox1.Text.Split(' ');
            DateTime _curTime = new DateTime(1, 1, 1, Convert.ToInt16(datas[0]), Convert.ToInt16(datas[1]), 0);
            double min = double.MaxValue;
            for (int i = 2; i < datas.Length; i += 2)
            {
                double rsult = 0;
                DateTime _checkSeq = new DateTime(1, 1, 1, Convert.ToInt16(datas[i]), Convert.ToInt16(datas[i + 1]), 0);
                if (_checkSeq.Subtract(_curTime).Minutes < 0)
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

        private void button17_Click(object sender, EventArgs e)
        {
            /*
             * Melbourne 10 59 85 100
             * San_Diego 18 20 61 96
             * Berlin 13 57 28 78
             * Guatamala 19 26 61 33
             * Lima 12 42 19 72 (-5)
             * Edmonton 09 07 67 79 (-6 ผิด)
             * Israel 23 28 91 58 (2 ผิด)
             * Taipei 17 51 27 116 (8)
             * Harare 07 45 62 27 (2 ผิด)
             * Cyprus 21 37 32 31 (3 ผิด)
             * Edinburgh 20 53 72 74 (1 ผิด)
             * Berlin 05 01 35 41 (2 ผิด)
             * Jakarta 10 36 30 93 (7)
             * Santa_Fe 12 59 114 59
            */
            List<String> listOfResult = new List<string>();
            String[] datas = textBox1.Text.Split(' ');

            DateTime _curTime = new DateTime(1, 1, 1, Convert.ToInt16(datas[1]), Convert.ToInt16(datas[2]), 0);
            int diff = (7 - Convert.ToInt16(datas[0]));
            diff = (diff > 0) ? diff * -1 : diff;
            _curTime = _curTime.AddHours(diff);
            listOfResult.Add(_curTime.ToString("HH mm"));

            for (int i = 3; i < datas.Length; i++)
            {
                _curTime = _curTime.AddMinutes(Convert.ToInt16(datas[i]));
                listOfResult.Add(_curTime.ToString("HH mm"));
            }



            textBox2.Text = string.Join(" ", listOfResult);
            Clipboard.SetText(textBox2.Text);
            Console.WriteLine();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int[] result = new int[10];
            String[] datas = textBox1.Text.Split(' ');
            int regist = Convert.ToInt16(datas[0]);
            int start = Convert.ToInt16(datas[1]);
            StringBuilder sb = new StringBuilder();
            for (int i = start; i <= regist; i++)
            {
                sb.Append(i + "");
            }

            result[0] = Regex.Matches(sb.ToString(), "0").Count;
            result[1] = Regex.Matches(sb.ToString(), "1").Count;
            result[2] = Regex.Matches(sb.ToString(), "2").Count;
            result[3] = Regex.Matches(sb.ToString(), "3").Count;
            result[4] = Regex.Matches(sb.ToString(), "4").Count;
            result[5] = Regex.Matches(sb.ToString(), "5").Count;
            result[6] = Regex.Matches(sb.ToString(), "6").Count;
            result[7] = Regex.Matches(sb.ToString(), "7").Count;
            result[8] = Regex.Matches(sb.ToString(), "8").Count;
            result[9] = Regex.Matches(sb.ToString(), "9").Count;

            textBox2.Text = string.Join(" ", result);
            Clipboard.SetText(textBox2.Text);
            Console.WriteLine();
        }


        private void button19_Click(object sender, EventArgs e)
        {
            String[] datas = textBox1.Text.Split(' ');
            int _startX = Convert.ToInt16(datas[0]);
            int _startY = Convert.ToInt16(datas[1]);
            SortedDictionary<Double, String> dict = new SortedDictionary<Double, String>();

            for (int i = 2; i < datas.Length; i += 2)
            {
                int x = Convert.ToInt16(datas[i]);
                int y = Convert.ToInt16(datas[i + 1]);
                Double xxx = GetDistance(_startX, _startY, x, y);
                dict.Add(xxx, x + " " + y);
                Console.WriteLine();

            }

            textBox2.Text = dict.ElementAt(dict.Count / 2).Value;
            Clipboard.SetText(textBox2.Text);
            Console.WriteLine();
        }


        private void button20_Click(object sender, EventArgs e)
        {
            /*
             * 3 19 33
             * [?]
             * --------------------------------
             * 30 94 55
             * [53]
             * --------------------------------
             * 100 32 48
             * [44]
             * --------------------------------
             * 100 17 100
             * [87]
             * --------------------------------
             * 
             */

            textBox6.Text = string.Empty;
            Cursor = Cursors.WaitCursor;
            DateTime startTime = DateTime.Now;

            String[] datas = textBox1.Text.Split(' ');
            int M = Convert.ToInt16(datas[0]);//fake
            int r = Convert.ToInt16(datas[1]);//real
            int K = Convert.ToInt16(datas[2]);
            int P = (M + r);


            BigInteger result =PermutationsAndCombinations.nCr(P, r);

            SortedDictionary<int, int> resultList = new SortedDictionary<int, int>();
            int resultXXX = 1;
            while (resultXXX < K)
            {
                if(result%resultXXX == 0)
                {
                    resultList.Add(resultXXX, resultXXX);
                }
                resultXXX++;
            }


            textBox2.Text = resultList.LastOrDefault().Value + "";
            Clipboard.SetText(textBox2.Text);
            DateTime endTime = DateTime.Now;
            label1.Text = String.Format("Use time: {0} (s)", endTime.Subtract(startTime).Seconds);
            Cursor = Cursors.Default;
        }


        public BigInteger Factorial(int factorial)
        {
            var bi = new BigInteger(1);
            for (var i = 1; i <= factorial; i++)
            {
                bi *= i;
            }
            return bi;
        }



        private void button21_Click(object sender, EventArgs e)
        {
            //0111001000 1879761132 2
            //20 > 01011011011001101111 93189445446861454348 8
            //10 > 0000010001 8334819558 3

            int result = 0;
            String[] datas = textBox1.Text.Split(' ');
            char[] bins = datas[0].ToCharArray();
            char[] calset = datas[1].ToCharArray();
            int select = Convert.ToInt16(datas[2]);
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();

            StringBuilder switchPanel = new StringBuilder(datas[0]);
            for (int i = 0; i < bins.Length; i++)
            {
                if (i + select <= bins.Length)
                {
                    for (int j = 0; j < select; j++)
                    {
                        switchPanel[j] = switchPanel[j].ToString().Equals("1") ? '0' : '1';
                    }
                    for (int j = 0; j < bins.Length; j++)
                    {
                        result += (switchPanel[j].ToString().Equals("1") ? Convert.ToInt32(calset[j].ToString()) : 0);
                    }
                    if (!dict.ContainsKey(result))
                    {
                        dict.Add(result, result);
                        result = 0;
                    }

                    Console.WriteLine();
                }
            }


            textBox2.Text = dict.LastOrDefault().Value.ToString();
            Clipboard.SetText(textBox2.Text);
        }

        public IEnumerable<IList<T>> Combinations<T>(IEnumerable<T> items, int choose)
        {
            if (items == null) throw new ArgumentNullException("items");

            var itemsList = items.ToList();
            int n = itemsList.Count;

            if (n < 1) throw new ArgumentException("Must contain at least one item.", "items");
            if (choose <= 0 || choose >= n) throw new ArgumentOutOfRangeException("choose");

            var indices = Enumerable.Range(0, choose).ToArray();

            bool moreWork = true;
            while (moreWork)
            {
                yield return indices.Select(i => itemsList[i]).ToList();

                moreWork = false;
                for (int i = choose - 1; i >= 0; i--)
                {
                    if (indices[i] < n - choose + i)
                    {
                        indices[i]++;
                        for (int j = i + 1; j < choose; j++)
                        {
                            indices[j] = indices[i] - i + j;
                        }
                        moreWork = true;
                        break;
                    }
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //50 50 YNNNYYNYNYYYYNYNYNNYNYNNYYNYNYYNNYYYNNNNNNNYYYYNYY YYYYNNNNNYYNYNNNNNYNNNNNYNYNNYNNYYNNNYYNYNYYNYYYNY YYYNNYYNNYYNNYYYNYYNNNYNNYYNNNNYYNYNYNNNNYNYYYNYYY YYNYNNYYYNNYYYYYNNYYYNNYNNYYNNNYNNNNYNYYNYNNYYYYNN YYYNNYYNNYYYNNNYNNNYYYYNYNYNYNYYNNYNYNYNYNNYNNYYYN NNNYYNYNNYNNNYYNNNYYNYYNYYYNYYNYYNYNNNYNNNYNNYYYYY YYNNNNYNNYYYNNNNYYYNYYNNYNYYNYNYYYYYYNYNYNNYNYNYNN NYNNYNNYNNYNNYNYYYYNYNYYNYNYNNYYYYNNNYYYYYYYNYYNYN NNNNYYNYYYYYYYYYYYYNNNYYYYNNYNNNNNNYYNYYYYNNNNNYYY NYYNYNNNYNNYYNNYYYNNNYNYNNYNNNYNYYNYYNNYYYNNYNYYYY NNYNYYNYNYNYNNYNNNNYYNYNYYNNNNNNNNNYNYYYYNNYYYNNNY YYYNYYYYYNYYYYNNYNYNYNYYNYYNYYYYNYNNYYNNYYNYNYYYNY YNNNYNNYNNYYYNYNNNNYNYNYNNYNYNNYNYYYYNNYNYYNNYYYYY NYYNNNNYNYNYYYYNNYNYYYYYYYYNYYYNNNNYYNYNNNYNYNNNNY NNYYNNNYYNYNYNYYYNNNNNNNNNYNYNYYNNNNYYNYNYYNYNNNNY NNYYNYNYYYYYYYYNNYYNYNYNYYNYYYYNNNNNNNNYNYYYNYYNYN NYYYNYYYNNNNNNYNYNNYYYYNNNYYNNNNNNYYNNYNNNYYNNYNYY YNNNYYNNNYYYYNYNYNNYNYYNYNYNNNNNYYYYNNNNYYYYYYNNYN YNYNYNYNYYYYYNNYYNNNYNYNNNYYYNYNYYNNNNYNNYNYNYNYYY YNNNYYNYNYNNNYYNYNNNNNNNYYYNYYNYNNYNYNYNYYYNYYNYNN YNNYNNNYYYNNYNNNYYYNNNNYNYYYYNNYNNNNYYYNNYYYYYNYNN NYNYNNNYYNYYYYNNNNNYYYNYNYNNNYNYYNNYNNNYYNYNYNYNYY NYYNYYNYYNYNYNYNNYYNYYYYYNNNYNYNYYNNNYYYNYYYYNYNNN NNNYYNYYYYYYYNNNYNNYNNYYYNNNYYYYYYNYNNYNYNNYNNNYNN NNYYYNYNNYYYNYNYNYYYYYYNNYYNNNYNNYNYYYNYNNNYYNNYNY NNYNNNYNNNYNYYYNNNNYNYYNYNYYNYYNYNYYNYYNYYYNNNYNNY YYYNYNYYNYNNNNYNNNNNYNYNNNNNYNNNNYNYYNNYNYNNNNNYNN YNNNNYYNYNYYYYYYNNYNYYNNYNNNNNNYYNNNNNNYNYYNNYYYNN YNNYYYYYNYNNYYYYYYYNYNYNYNNYNNYYYNNNNYNNYYYYNYNYNN NYYYNYNNNYNNYNNNYNYYNYNNYYYNNNYNYYYYNNNYYYYYYNYYYY YNYYNYYYYNNYYYNNYYYNNNNNNNNNYNNNNYYYYNYYNYYYYNNNYY YYYNNNNYNYNNNNNNNNYYNYYNNYYYNNNYYYYNNNNYNNYNNNNNNY NNYYYNYYNYYNYYNYNNNYNYNYNYYYNNYNNNNNYNYNYYNNYYNNYN NNNNYNYYYYNNYYNNNYYNYNYYYYNNNNNYNNNYYNYYYYNYYYNYYN NNYNYYNNYYYYYYNYYNYYYNYNYYYNYYYYNYYYYNNNNNYNNNNYNN YYNNNYYYYNYYNYNNYNNYNNNNYYYYYYNNYYNYNYNYYNYNYNNNNN NYYYNYNNYNNNYYYYNNNYNNNNYNNYNNYYYYYNYYNNYNNYYYNYYN YNNNYYYYNYNNNYNNNYNNNNYYYYYNNYYNYYYNYYNYYYYNNYNNYN YYYNNYNNYYYNYNNNNYYNNYNNYYNNNNYYNYNYNNYYNYNYYNYNYN YYNYYYNYYNNYNYNNYNNNNNYNYYYYNYYYYYYNNYYYNYYYYNNNYN NNYYNNYNNYNYYNYYNNYNYYYYNYYNYNYYNYNNYNNNYYNYYNYYYY NNNYYYYYNNNYNNNNYNNNYNNNNYNNNNNYNYYNYNNNYNYYNNNNNY NYYNNNNYNYYNNNYNYNYYNYYNNNYNYYNNYNNNNYNYYNNYNNNNYY NYNNYYNYYNYNNNNNYYYNYNNYNYNYYYYNYYYNYNYYYYNNNYYNYN NNNYYNYNNYYYNYYYNYYNYYYYNNNYNNNYNYNYYNNNNNNNYNNYNY NNYYYNYNNNYYNNNYYYYNYYYYYNNYNNNYYNNYYYNNYYNYYYNNNN NYYYYYYYYYYNYYYNYYNYNYNYYYYYYNYYYNNNNYYNYNYNYYNNNN NYNNYYYNYNYNYNNNNYYYYNYNNNYYYYYNNYYYNNYNYYNNYYNNNN NYNNNYNNYYNNYYNNYNYNYNYNYYNNNYNNNYYYNNNYNYNNNYNNYN NNNNNYYNYNNYNNYNYYYYYYNYNYNYNNYYNNYYNNYYNYYYYYNNYN
            //ANS: 2147483647
            //6 8 YNYNYNYN NYNYNNYY YNNNYNNN NNNNNNNN NYYNNNNN NYYNNNYN
            //6 8 YYYNYNYN YYYYYYNN YNNNYYYN NNNNNYYY NYYNNNNN NNYYYYYY
            String[] datas = textBox1.Text.Split(' ');
            int R = datas[0].Length;
            int C = datas.Length;
            long result = 0;
            char[] inputSet = datas[1].ToCharArray();
            SortedDictionary<String, String> dict = new SortedDictionary<String, String>();

            foreach (String s in datas)
            {
                Permutations<char> permutations = new Permutations<char>(s.ToCharArray());
                foreach (IList<char> p in permutations)
                {
                    StringBuilder letter = new StringBuilder();
                    for (int i = 0; i < p.Count; i++)
                    {
                        letter.Append(p[i]);
                    }
                    if (!dict.ContainsKey(letter.ToString()))
                    {
                        dict.Add(letter.ToString(), letter.ToString());
                    }
                    Console.Write(String.Format("}}"));
                    Console.WriteLine();
                }

            }
            Console.WriteLine();
            //SortedDictionary<int, int> dict = new SortedDictionary<int, int>();

            //Permutations<char> permutations = new Permutations<char>(inputSet);
            //foreach (IList<char> p in permutations)
            //{
            //    //Console.Write(String.Format("{{"));
            //    for (int i = 0; i < p.Count; i++)
            //    {
            //        Console.Write(String.Format(" {0} ", p[i]));
            //    }
            //    Console.Write(String.Format("}}"));
            //    Console.WriteLine();
            //}


            //Combinations<char> Cx = new Combinations<char>(inputSet, C);


            //Console.WriteLine(String.Format("{0} choose {1} = {2}", Cx.UpperIndex,
            //      Cx.LowerIndex, Cx.Count));

            textBox2.Text = result.ToString();
            Clipboard.SetText(textBox2.Text);
        }

        private static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
        //public List<String> getListRow(String rawData, int C)
        //{
        //    textBox6.Text += String.Format("##-Row-##\r\n");
        //    List<String> Rows = new List<string>();
        //    for (int x = 0; x < rawData.Length; x += C)
        //    {
        //        StringBuilder str = new StringBuilder(rawData.Substring(x, C));

        //        if (IsPalindrome(str.ToString()))
        //        {
        //            if (!parinPos.Contains(x))
        //            {
        //                parinPos.Add(x);
        //            }
        //            _RN++;
        //        }
        //        textBox6.Text += String.Format("{0} = {1}\r\n", str, IsPalindrome(str.ToString()) ? "Y" : "N");

        //        Rows.Add(str.ToString());

        //    }
        //    Console.WriteLine();
        //    return Rows;
        //}
        //public List<String> getListCol(List<String> Rows)
        //{
        //    textBox6.Text += String.Format("##-Col-##\r\n");
        //    List<String> RowsCol = new List<string>();
        //    for (int c = 0; c < Rows.Count; c++)
        //    {
        //        String str = "";
        //        for (int r = 0; r < Rows.Count; r++)
        //        {

        //            str += Rows[r][c];
        //        }
        //        if (IsPalindrome(str))
        //        {
        //            _CN++;
        //        }
        //        textBox6.Text += String.Format("{0} = {1}\r\n", str, IsPalindrome(str.ToString()) ? "Y" : "N");
        //        RowsCol.Add(str);

        //    }

        //    return RowsCol;
        //}

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

        private void button23_Click(object sender, EventArgs e)
        {
            /*
             59:72 14:90 57:36 14
             */
        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            /*
             * 
             QUES: *** *.* **. ..* *.* ..* *.. ..* *** **. **. ..* .** .** *** ... .*. *** *.. *.* ... ..* ..* *.. .*. **. *.. **. **. *.* .*. .*. **. ..* **. *.* .** ..* *** *.* *** **. **. ... **. **. .*. .** .** *.*
             ANS:[26]
             .*. .*. *..
            [3]
            **. *.. ..*
            [3]
            .*. *.* .**
            [5]
            *** *.. .**
            [6]
            *.. *** ...
            [4]
            ..* **. *.. .** **. *.*
            [8]
             */
            List<String> workedPos = new List<string>();
            int result = 0;
            String[] datas = textBox1.Text.Split(' ');


            //List<String> Rows = (from Match m in Regex.Matches(String.Join("",datas), @"\d{3}") select m.Value).ToList();
            textBox6.Text += String.Format("{0}\r\n", String.Join(" ", datas));

            //Permutations<char> permutations = new Permutations<char>("110".ToString().ToCharArray());
            //foreach (IList<char> p in permutations)
            //{
            //    for (int i = 0; i < p.Count; i++)
            //    {
            //        textBox6.Text += String.Format("{0}\r\n",String.Join(" ",p));
            //    }


            //}

            //List<String> Rows = getListRow(textBox1.Text.Replace(" ", "").Replace("*", "*").Replace(".", "+"), 3);
            //foreach (String r in Rows)
            //{
            //    textBox6.Text += String.Format("{0} {1} {2}\r\n", r[0], r[1], r[2]);
            //}

            //for (int r = 0; r < datas.Length; r++)
            //{
            //    textBox1.Text += String.Format("{0}{1}{2}\n", datas[r][0], datas[r][1], datas[r][2]);
            //    //for (int c = 0; c < datas[r].Length; r++)
            //    //{
            //    //    String letter = datas[r][c].ToString();
            //    //    if (!letter.Equals("*"))
            //    //    {
            //    //        continue;
            //    //    }
            //    //    result += Regex.Matches(letter, "\\*").Count;
            //    //    result += go4Way(datas,r+,c+);


            //    //    Console.WriteLine();
            //    //}
            //}

            Console.WriteLine();
            //List<String> Rows = getListRow(textBox1.Text.Replace(" ", "").Replace("*","9"), length);
            //for(int x=0;x<length)
            //for(int i = 0; i <= Rows.Count-length; i+=length)
            //{
            //    String top = Rows[i];
            //    String midden = Rows[i+1];
            //    String bottom = Rows[i+2];

            //    if (top.Equals("..."))
            //    {
            //        top = "9..";
            //        Console.WriteLine();
            //        //break;
            //    }

            //    for(int j = 0; j < top.Length; j++)
            //    {

            //        if (top[j].ToString().Equals("9"))
            //        {
            //            result++;
            //            result += Regex.Matches(midden[j].ToString(), "9").Count;
            //            if (midden[j].ToString().Equals("9"))
            //            {
            //                result += Regex.Matches(bottom[j].ToString(), "9").Count;
            //            }
            //        }
            //        Console.WriteLine();
            //    }
            //   //result += Regex.Matches(bomp, "9").Count;
            //    Console.WriteLine();
            //}
            textBox2.Text = result + "";
            Clipboard.SetText(textBox2.Text);
            Console.WriteLine();

        }

        private int go4Way(String[] datas, int r, int c)
        {
            int originalC = c;
            int originalR = r;
            int result = 0;
            String letter = datas[r][c].ToString();
            while (letter.Equals("*"))
            {
                letter = datas[r++][c].ToString();
                result += Regex.Matches(letter, "\\*").Count;
            }

            //r = originalR;
            //c = originalC;
            //letter = letter = datas[(r==0)? 0:--r][c].ToString();
            //while (letter.Equals("*") && r>0)
            //{
            //    letter = datas[(r == 0) ? 0 : --r][c].ToString();
            //    result += Regex.Matches(letter, "\\*").Count;
            //}
            return result;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            /*
             [..VC..EQQR.YMH..I....UMERLN.BK.F.X.I..V...X.H.OB.. ....O.FXT.FMR..SN.IEGC..HVYUZ...QB.....M.WPLXKE.B.]
             
             */
        }

        private void button27_Click(object sender, EventArgs e)
        {
            /*
                1 32 6 60 90 21 31 37 40 79
                2 18 31 3 13 37 92 20 90 58 [IMPOSSIBLE]
             */
        }
        //private string GetNthBinaryPalindrome(int n)
        //{
        //    switch (n)
        //    {
        //        case 1:
        //            return "0";
        //        case 2:
        //            return "1";
        //        case 3:
        //            return "11";
        //        case 4:
        //            return "101";
        //        case 5:
        //            return "111";
        //        default:
        //            if (n < 1)
        //                return null;

        //            var S = n - 3;
        //            var groupIndex = (int)Math.Floor(Math.Log((S / 3) + 1, 2));
        //            var digitsCount = group;
        //            var subGroupCount = (int)Math.Round(Math.Pow(2, group));
        //            var Sn = (subGroupCount - 1) * 3;
        //            var insideGroupIndex = S - Sn;
        //            var subGroupIndex = insideGroupIndex % subGroupCount;
        //            var opType = (int)Math.Floor((double)insideGroupIndex / subGroupCount);

        //            string leftSide;
        //            string connector;

        //            switch (opType)
        //            {
        //                case 0:
        //                    connector = "";
        //                    leftSide = "1" +
        //                    Convert.ToString(subGroupIndex, 2).PadLeft(digitsCount, '0');
        //                    break;
        //                case 1:
        //                    connector = ((groupIndex & 1) == 0) ? "0" : "1";
        //                    leftSide = "1" +
        //                    Convert.ToString(subGroupIndex / 2, 2).PadLeft(digitsCount, '0');
        //                    break;
        //                case 2:
        //                    connector = ((groupIndex & 1) == 0) ? "0" : "1";
        //                    leftSide = "1" + Convert.ToString(subGroupIndex / 2 +
        //                    subGroupCount / 2, 2).PadLeft(digitsCount, '0');
        //                    break;
        //                default:
        //                    return null;
        //            }

        //            return String.Format("{0}{1}{2}",
        //            leftSide, connector, String.Join("", leftSide.Reverse()));
        //    }
        //}

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



    //public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
    //{
    //    return k == 0 ? new[] { new T[0] } :
    //      elements.SelectMany((e, i) =>
    //        elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
    //}



}

public static class PermutationsAndCombinations
{
    public static BigInteger nCr(int n, int r)
    {
        // naive: return Factorial(n) / (Factorial(r) * Factorial(n - r));
        return nPr(n, r) / Factorial(r);
    }

    public static BigInteger nPr(int n, int r)
    {
        // naive: return Factorial(n) / Factorial(n - r);
        return FactorialDivision(n, n - r);
    }

    private static BigInteger FactorialDivision(int topFactorial, int divisorFactorial)
    {
        BigInteger result = 1;
        for (int i = topFactorial; i > divisorFactorial; i--)
            result *= i;
        return result;
    }

    public static BigInteger Factorial(int i)
    {
        if (i <= 1)
            return 1;
        return i * Factorial(i - 1);
    }

    //public staic int Factorial2(this int count)
    //{
    //    return count == 0
    //               ? 1
    //               : Enumerable.Range(1, count).Aggregate((i, j) => i * j);
    //}
}

//public static class Ex
//{
//    public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(this IEnumerable<T> elements, int k)
//    {
//        return k == 0 ? new[] { new T[0] } :
//          elements.SelectMany((e, i) =>
//            elements.Skip(i + 1).DifferentCombinations(k - 1).Select(c => (new[] { e }).Concat(c)));
//    }
//}

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


