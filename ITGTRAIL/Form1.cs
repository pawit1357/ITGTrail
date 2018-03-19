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

            int startX = 0;
            int startY = 0;
            int destX = Convert.ToInt32(datas[0]);
            int destY = Convert.ToInt32(datas[1]);

            int v = Convert.ToInt32(datas[2]);//V (m/s)
            int u = Convert.ToInt32(datas[3]);//U (m/s) x-axis


            String resultText = "IMPOSSIBLE";
            int time = 0;
            Boolean isLoop = true;
            while (isLoop)
            {
                startX += u;
                startY -= v;

                if (startX == destX && startY == destY)
                {
                    isLoop = false;
                }
                if (startX > destX && startY < destY)
                {
                    time = -1;
                    break;
                }
                //Console.WriteLine(String.Format("{0},{1}    {2},{3}",destX,startX,destY,startY));
                time++;
            }

            textBox2.Text = (time == -1) ? resultText : time + "";
            Clipboard.SetText(textBox2.Text);

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
             * 
             */

            Cursor = Cursors.WaitCursor;

            int result = 0;

            String[] datas = textBox1.Text.Split(' ');
            int R = Convert.ToInt16(datas[0]);
            int C = Convert.ToInt16(datas[1]);
            String rawData = datas[2];
            int RN = Convert.ToInt16(datas[3]);
            int CN = Convert.ToInt16(datas[4]);

            String init = "0000";
            for (int r = 0; r < R; r++)
            {
                StringBuilder sb = new StringBuilder();
                for (int c = 0; c < C - 1; c++)
                {

                }
            }

            //StringBuilder sb = new StringBuilder(rawData);
            //string reverseValue = new string(rawData.Reverse().ToArray());
            //Console.WriteLine();
            //if (rawData.Equals(sb, StringComparison.OrdinalIgnoreCase))
            //{
            //    Console.WriteLine("The string is pallindrome");
            //}

            //for (int r = 0; r < R; r++)
            //{
            //    for (int c = 0; c < C; c++)
            //    {

            //    }
            //}

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
                    //textBox6.Text += String.Format("Result: {0} {1} * LOCKY!\r\n", totalRn, totalCn);
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
                textBox6.Text += String.Format("{0} {1}\r\n", String.Join(" ", rWord.ToCharArray()), isPldR ? "Y" : "N");

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
             * Yakutsk 21 08 23 113 (9)
             * Guam 08 53 78 37 (10)
             * Indiana_[east] 19 45 19 60 [-5]
            */
            List<String> listOfResult = new List<string>();
            String[] datas = textBox1.Text.Split(' ');

            DateTime _curTime = new DateTime(1, 1, 1, Convert.ToInt16(datas[1]), Convert.ToInt16(datas[2]), 0);
            int diff = (7 - Convert.ToInt16(datas[0]));
            //diff = (diff > 0) ? diff * -1 : diff;
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
                if (!dict.ContainsKey(xxx))
                {
                    dict.Add(xxx, x + " " + y);
                }
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


            BigInteger result = PermutationsAndCombinations.nCr(P, r);

            SortedDictionary<int, int> resultList = new SortedDictionary<int, int>();
            int resultXXX = 1;
            while (resultXXX <= K)
            {
                if (result % resultXXX == 0)
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
            //100> 0000011011110110110001110100101111011011000111111110100001001111011111100111000100010100100100010101 3825617787463631537434877328486974466485374815769882783746632795123144723913573289915735627878799314 1
            /*
            0000010001
            1110010001
            1001010001
            1010110000
            */




            String[] datas = textBox1.Text.Split(' ');
            char[] bins = datas[0].ToCharArray();
            char[] calset = datas[1].ToCharArray();
            int select = Convert.ToInt16(datas[2]);
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
            StringBuilder switchPanel = new StringBuilder(datas[0]);

            List<String> listofNew = new List<string>();
            StringBuilder word = new StringBuilder(datas[0]);
            listofNew.Add(word.ToString());
            for (int i = 0; i < bins.Length - select; i++)
            {
                for (int j = 0; j < select; j++)
                {
                    String posValue = word[i + j].ToString().Equals("1") ? "0" : "1";
                    word.Remove(i + j, 1);
                    word.Insert(i + j, posValue);

                    Console.WriteLine();

                }

                listofNew.Add(word.ToString());
                Console.WriteLine();

            }
            foreach (String item in listofNew)
            {
                int result = 0;
                char[] value = item.ToCharArray();
                for (int i = 0; i < value.Length; i++)
                {
                    String posValue = value[i].ToString();
                    result += (posValue.Equals("1") ? Convert.ToInt32(calset[i].ToString()) : 0);
                }
                if (!dict.ContainsKey(result))
                {
                    dict.Add(result, result);
                    result = 0;
                }
                Console.WriteLine();
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
            //*.* *.. *.. .*. ... ..* *.* .*. *.. .*. .** ... .*. *.* ..* **. ... *.. *.. **. .** .*. ..* .** .*. *.* ..* *.. *.. *** ..* ... ... *** *.* **. *.. **. ... .*. *** .*. *.* **. ..* ..* .*. .*. ... ..*
            //... .*. **. **. ..* *** ..* *.. .** *.. **. .** *** .*. ... *.* .** *** ... *.. *.. .** *.* *** **. **. *** .** ... ..* .*. .*. .** **. .** ..* .** *** *.* .** ..* ..* .** **. .*. .** .** *** *** ..*
            //**. **. *** ..* *.. *.. **. *** *** *.. .*. *** .** ... .** ..* .*. *.. *.. *.* ..* ..* *.. .** .*. *.. *** ..* ... .*. ... *.* .** **. *** **. *** ..* .** *.* .** *.* ... ..* *** .*. ... *.* **. ...
            //[25]
            //.*. .** *.. .*. *** *.. *.. .*. ..* *** *.. .** ..* ... .*. *.. ... *** ..* .** *** *** .** ... **. .*. *** **. .*. *.. **. ..* **. ..* ... .** ..* ... .*. ... *.. **. ..* ... .** .*. *** **. *.. *..
            //[23]
            //*** *.. .** .** ..* *.. .** ..* *.. *.* *.. *.. *** *.. ..* *.* .** .*. **. **. .*. .*. *.* ... *.* ..* .*. .*. *** *.. .** ..* *** **. **. .** ... *.. *.. ..* *** .*. *** .** *.. .** *** ... ... ..*
            //[19]
            //.*. **. *.. .*. .** *.* .** ... *.. ..* *** .*. **. *** *.. *.. .*. *** *.. ... *.* **. .** **. **. ... .** .*. ..* ... .*. *** .** *** ... **. .** *** *.. ... .** *** *** ... **. .*. *.. *** ... *..
            //[17]
            //*.* ..* ..* *.* ..* ... *.. *** *.* **. .** *.. .*. .*. *.. ..* *.. **. ... .*. ..* *.* ... ..* *** *.* ..* ... *.* **. ... *** *.. *** .** *.. .** *.. *.. *** *.* **. *** .** **. *.* .** *.* *.* **.
            //[26]
            //.*. ... **. .** .** ... .*. .** .** ... .** *** .** ..* *.. ... *.* *.* .*. .*. **. ..* *** .*. *.. .** *.* *** *** .** .** .** .** *.* *.* ... *.* **. **. **. *** ..* .** .** *.* **. **. .** .** ...
            //[26]
            //*.* *** .** .*. *** ... .** ... *.. .** **. ..* ..* *.. *** *** *.. *.* .** *** .*. *** **. **. *** .*. *** .*. ... .*. *.. ..* .** *** *.* ... *** **. .** *.* .*. *** *.* **. .** ... *.* *.. **. *..
            //[31]
             * */
            List<String> workedPos = new List<string>();
            int result = 0;

            List<int> listOfBompIndex = new List<int>();
            /*
        * HackerRank problem statement comes with a sample test case. 
        * sample input
        * 4
        * 4
        * 0 0 0 
        * 0 1 1 
        * 0 0 1
        * 1 1 0 
        * sample output: 5
        */
            String[] matrix = textBox1.Text.Replace('.', '0').Replace('*', '1').Split(' ');
            #region "TEST01"
            //Dictionary<String, String> db = new Dictionary<string, string>();
            //db.Add("001", "011,101,111");
            //db.Add("010", "110,010,011");
            //db.Add("011", "011,010,001,110");
            //db.Add("100", "111,110");
            //db.Add("101", "100,110,111,011,001");
            //db.Add("110", "100,010,011,101");
            //db.Add("111", "111,110,101,011");
            //001
            //110
            //100
            //011
            //110
            //101
            //int count = 0;
            //int index = 0;
            String lastLine = "";
            //for (int i = 0; i < datas.Length-1; i ++)
            //{
            //    String currentLine = datas[i];

            //    if (db.ContainsKey(currentLine))
            //    {
            //        String[] currentLineDbValue = db[currentLine].Split(',');
            //        String downLine = datas[i + 1];
            //        if (currentLineDbValue.Contains(downLine))
            //        {
            //            if (!currentLine.Equals(lastLine))
            //            {
            //                count += Regex.Matches(currentLine, "1").Count;
            //                lastLine = downLine;
            //            }
            //            count += Regex.Matches(downLine, "1").Count;
            //            Console.WriteLine();
            //        }
            //        else
            //        {
            //            count = 0;
            //            Console.WriteLine();
            //        }
            //    }
            //}
            #endregion

            int rows = matrix.Length;
            int cols = 3;


            int[,] arr = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                textBox6.Text += String.Format("{0}\r\n", String.Join(" ", matrix[i].ToCharArray()));
                string[] colA = String.Join(" ", matrix[i].ToCharArray()).Split(' ');
                for (int j = 0; j < cols; j++)
                    arr[i, j] = Convert.ToInt32(colA[j]);
            }
            int xx = Q21Lib.GetNumberOfCellsInLargestRegion(arr, rows, cols);
            Console.WriteLine();

            textBox2.Text = xx.ToString();
            Clipboard.SetText(textBox2.Text);
            Console.WriteLine();
        }
        public List<int> findColHaveBompByRow(String[] _datas, int startRow, int col)
        {
            List<int> pos = new List<int>();
            for (int r = (startRow + 1); r < _datas.Length; r++)
            {
                Char[] currentLines = _datas[r].ToCharArray();
                if (currentLines[col] == '1')
                {
                    int returnPos = (r * currentLines.Length) + col;
                    pos.Add(returnPos);
                }
                else
                {
                    return pos;
                }
            }
            return pos;
        }
        //int[,] maze = new int[3, 3];
        //Boolean solveMaze(int row, int col)
        //{
        //    // Try to solve the maze by continuing current path from position
        //    //พยายามแก้ปัญหาเขาวงกตอย่างต่อเนื่องโดยในปัจจุบันเส้นทางจากตำแหน่ง
        //    // (row,col).  Return true if a solution is found.  The maze is
        //    //(แถว, col) กลับจริงถ้าแก้ปัญหาที่พบ เขาวงกตเป็น
        //    // considered to be solved if the path reaches the lower right cell.
        //    //พิจารณาที่จะแก้ไขหากเส้นทางถึงเซลล์ขวาล่าง
        //    if (maze[row][col] == emptyCode)
        //    {
        //        maze[row][col] = pathCode;      // add this cell to the path
        //                                        //เพิ่มเซลล์นี้เส้นทาง
        //        if (checkStatus() == TERMINATE)
        //            return false;
        //        putSquare(row, col, pathCode);
        //        if (row == rows - 2 && col == columns - 2)
        //            return true;  // path has reached goal
        //                          //เส้นทางได้ถึงเป้าหมาย

        //        if ((solveMaze(row - 1, col) && checkStatus() != TERMINATE) ||
        //             // try to solve maze by extending path
        //             //พยายามแก้ปัญหาโดยการขยายเส้นทางเขาวงกต
        //             (solveMaze(row, col - 1) && checkStatus() != TERMINATE) ||
        //             //    in each possible direction
        //             //ทิศทางในการไปแต่ละ
        //             (solveMaze(row + 1, col) && checkStatus() != TERMINATE) ||
        //             solveMaze(row, col + 1))
        //            return true;
        //        if (checkStatus() == TERMINATE)
        //            return false;
        //        // maze can't be solved from this cell, so backtract out of the cell
        //        //เขาวงกตไม่สามารถแก้ไขได้จากเซลล์นี้เพื่อ backtract ออกจากเซลล์
        //        maze[row][col] = visitedCode;  // mark cell as having been visited
        //                                       //เซลล์ทำเครื่องหมายว่าได้รับชม
        //        putSquare(row, col, visitedCode);
        //        synchronized(this) {
        //            try { wait(speedSleep); }
        //            catch (InterruptedException e) { }
        //        }
        //        if (checkStatus() == TERMINATE)
        //            return false;
        //    }
        //    return false;
        //}

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

        IEnumerable<List<T>> Permutations<T>(List<T> items)
        {
            if (items.Count == 0) yield return new List<T>();

            var copy = new List<T>(items);
            foreach (var i in items)
            {
                copy.Remove(i);
                foreach (var rest in Permutations(copy))
                {
                    rest.Insert(0, i);
                    yield return rest;
                }
                copy.Insert(0, i);
            }

        }

        IEnumerable<string> Anagrams(string word)
        {
            return Permutations(word.ToCharArray().ToList()).Select(x => new String(x.ToArray()));
        }
        private void button26_Click(object sender, EventArgs e)
        {
            /*
 Z..DF.SDMTLQ.UW....HEH.L..D.F.ENK.S.S.BEF.P..QR.VG ....H....EG.E..FU.BBJFN....T..DP.DO.......S.ZLDGM.
[ZAADFASDMTLQAUWAAAAHEHALAADAFAENKASASABEFBPGJQROVG AAAAHAAAAEGAEAAFUABBJFNAAAATEFDPHDOKLQQRSSSVZLDGMW]  
----------------------------
50
..W...DQ.Y...DZ.U....FT.E..UV.BV..SMT.....V.E...W. ...CT..VTFVIWX...PF...TD.H...HU..V.PB.L...EEEV....
[AAWAAADQAYAAADZAUAAAAFTAEAAUVABVCESMTFHHILVPEPTVWX AAACTAAVTFVIWXAAAPFAAATDAHAAAHUAAVAPBDLMQSEEEVUWYZ]
 AAWAAADQAYAAADZAUAAAAFTAEAAUVABVAASMTAAAAAVAEAAAWA 
 AAWAAADQAYAAADZAUAAAAFTAEAAUVABVAASMTAAAACVHEILPWX AAACTAAVTFVIWXAAAPFAAATDAHAAAHUAAVAPBALAAMEEEVQSYZ
----------------------------
25......TC..P.E.GBJ....W..U ....EOKBCU.TJB...Y.W....E
[ AAAAAATCAAPAEAGBJABEKWOYU AAAAEOKBCUATJBAAAYAWAAGPE]
..YPOS ...OGC
[CGYPOS PSYOGC]
..FLT L.PTF
[APFLT LAPTF]
             */

            String[] datas = textBox1.Text.Split(' ');
            int dotALength = Regex.Matches(datas[0].ToString(), "\\.").Count;
            int dotBLength = Regex.Matches(datas[1].ToString(), "\\.").Count;


            char[] _aChars = datas[0].Replace(".", "").Trim().ToCharArray();
            char[] _bChars = datas[1].Replace(".", "").Trim().ToCharArray();
            StringBuilder aChar = new StringBuilder(String.Join("", _aChars));
            StringBuilder bChar = new StringBuilder(String.Join("", _bChars));
            StringBuilder tmpBChar = new StringBuilder(String.Join("", _bChars));
            List<String> A = new List<String>();
            List<String> B = new List<String>();
            List<String> tempA = new List<String>();

            for (int i = 0; i < bChar.Length; i++)
            {
                String letter = bChar[i].ToString();

                if (aChar.ToString().IndexOf(letter) != -1)
                {
                    if (!tempA.Contains(letter))
                    {
                        tempA.Add(letter);
                        bChar[i] = '-';
                    }
                    Console.WriteLine();
                }
            }
            for (int i = 0; i < bChar.Length; i++)
            {
                if (bChar[i] != '-')
                    B.Add(bChar[i].ToString());
            }
            Console.WriteLine();
            //////
            List<String> tempB = new List<String>();

            for (int i = 0; i < aChar.Length; i++)
            {
                String letter = aChar[i].ToString();

                if (tmpBChar.ToString().IndexOf(letter) != -1)
                {
                    if (!tempB.Contains(letter))
                    {
                        tempB.Add(letter);
                        aChar[i] = '-';
                    }
                    Console.WriteLine();
                }
            }
            for (int i = 0; i < aChar.Length; i++)
            {
                if (aChar[i] != '-')
                    A.Add(aChar[i].ToString());
            }
            ////




            A.Sort();
            B.Sort();
            //make anagram a
            StringBuilder AAALAST = new StringBuilder();
            int ARemain = dotALength - B.Count;
            for (int i = 0; i < B.Count; i++)
            {
                AAALAST.Append(B[i]);
            }

            StringBuilder AAAFIRST = new StringBuilder();
            for (int i = 0; i < ARemain; i++)
            {
                AAAFIRST.Append("A");
            }
            AAAFIRST.Append(AAALAST.ToString());
            ///

            StringBuilder BBBLAST = new StringBuilder();
            int BRemain = dotBLength - A.Count;

            for (int i = 0; i < A.Count; i++)
            {
                BBBLAST.Append(A[i]);
            }

            StringBuilder BBBFIRST = new StringBuilder();
            for (int i = 0; i < BRemain; i++)
            {
                BBBFIRST.Append("A");
            }
            BBBFIRST.Append(BBBLAST.ToString());

            StringBuilder ResultA = new StringBuilder(datas[0]);
            int indexA = 0;
            for (int i = 0; i < ResultA.Length; i++)
            {
                if (ResultA[i] == '.')
                {
                    ResultA[i] = AAAFIRST[indexA];
                    indexA++;
                }
            }
            StringBuilder ResultB = new StringBuilder(datas[1]);
            int indexB = 0;
            for (int i = 0; i < ResultB.Length; i++)
            {
                if (ResultB[i] == '.')
                {
                    ResultB[i] = BBBFIRST[indexB];
                    indexB++;
                }
            }
            textBox2.Text = String.Format("{0} {1}", ResultA.ToString(), ResultB.ToString());
            Clipboard.SetText(textBox2.Text);


        }



        public static string intersection2(string x1, string x2)
        {
            string[] string1 = String.Join(" ", x1.ToCharArray()).Split(' ');// x1.Split(' ');
            string[] string2 = String.Join(" ", x2.ToCharArray()).Split(' ');
            var m = string1.Distinct();
            var n = string2.Distinct();

            var results = m.Intersect(n, StringComparer.OrdinalIgnoreCase);
            //The result is a list of string, so we just have to concat them
            var test = " ";
            foreach (var k in results) test += k + " ";
            return test;
        }
        public Dictionary<string, string> PairAnagrams(List<string> words)
        {
            Dictionary<string, string> pairedAnagrams = new Dictionary<string, string>();
            foreach (var word in words)
            {
                if (pairedAnagrams.ContainsValue(word))
                {
                    continue;
                }

                var sortedWord1 = word.OrderBy(c => c);
                int wordLength = word.Length;
                foreach (var word2 in words.Where(w => w.Length == wordLength && !word.Equals(w)))
                {
                    if (sortedWord1.SequenceEqual(word2.OrderBy(c => c)))
                    {
                        pairedAnagrams.Add(word, word2);
                    }
                }
            }
            return pairedAnagrams;
        }

        public bool anagramChecker(string first, string second)
        {
            if (first.Length != second.Length)
                return false;

            if (first == second)
                return true;//or false: Don't know whether a string counts as an anagram of itself

            Dictionary<char, int> pool = new Dictionary<char, int>();
            foreach (char element in first.ToCharArray()) //fill the dictionary with that available chars and count them up
            {
                if (pool.ContainsKey(element))
                    pool[element]++;
                else
                    pool.Add(element, 1);
            }
            foreach (char element in second.ToCharArray()) //take them out again
            {
                if (!pool.ContainsKey(element)) //if a char isn't there at all; we're out
                    return false;
                if (--pool[element] == 0) //if a count is less than zero after decrement; we're out
                    pool.Remove(element);
            }
            return pool.Count == 0;
        }
        private void button27_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;
            DateTime startTime = DateTime.Now;
            /*
             * 
             *  100 1 32 12 7 69 49 63 23 9 68 [11] ผิด
                100 1 32 6 60 90 21 31 37 40 79 []
                100 2 18 31 3 13 37 92 20 90 58 [IMPOSSIBLE]
                50 1 62 22 51 9 49 72 5 99 87  [9]
                70 2 13 19 41 92 6 64 61 78 60  [IMPOSSIBLE]
                --------- 50
                [1] 62 22 51 9 49 72 5 99 87 -> 49
                1 62 22 51 [9] 49 72 5 99 87 -> 40
                1 62 22 51 9 49 72 [5] 99 87 -> 35
                [1] 62 22 51 9 49 72 5 99 87 -> 34
                1 62 [22] 51 9 49 72 5 99 87 -> 12
                1 62 22 51 [9] 49 72 5 99 87 -> 3
                [1] 62 22 51 9 49 72 5 99 87 -> 2
                [1] 62 22 51 9 49 72 5 99 87 -> 1
                [1] 62 22 51 9 49 72 5 99 87 -> 0

                --------- 7
                [1] 2 4 7 19 45 67 89 91 99 -> 6
                1 [2] 4 7 19 45 67 89 91 99 -> 4
                1 2 [4] 7 19 45 67 89 91 99 -> 0
                ------------
                500 1 6 76 92 79 86 30 42 52 43
                [16]

                100 1 32 12 7 69 49 63 23 9 68 [11] ผิด
                 ------------
                1000 2 79 30 11 27 89 67 33 39 75 
                [IMPOSSIBLE]
                 ------------
                1000 1 65 89 9 3 74 63 66 50 79
                [21]
                 ------------
                1000 2 92 14 36 6 67 76 96 4 50
                [IMPOSSIBLE]

             */

            String resultText = "IMPOSSIBLE";
            int result = 0;
            List<int> coinSet = new List<int>();

            String[] datas = textBox1.Text.Split(' ');
            int N = Convert.ToInt16(datas[0]);


            SortedDictionary<int, int> coinSetAndValue = new SortedDictionary<int, int>();
            for (int i = 1; i < datas.Length; i++)
            {
                coinSet.Add(Convert.ToInt32(datas[i]));
                coinSetAndValue.Add(coinSet[i - 1], 0);
            }

            coinSet.Sort();
            int remain = N;
            while (remain > 0)
            {
                foreach (int coin in coinSet)
                {
                    if (remain - coin >= 0)
                    {
                        coinSetAndValue[coin] = coinSetAndValue[coin] + 1;
                        remain -= coin;
                    }
                }
            }

            textBox2.Text = (result == -1) ? resultText : result + "";
            Clipboard.SetText(textBox2.Text);

            DateTime endTime = DateTime.Now;
            label1.Text = String.Format("Use time: {0} (s)", endTime.Subtract(startTime).Seconds);
            Cursor = Cursors.Default;

        }

        int[] coins;



        public int CoinCentral(int input)
        {
            int[] tempCoins = new int[input + 1];
            for (int a = 1; a < tempCoins.Length; a++)
            {
                tempCoins[a] = int.MaxValue;
            }
            tempCoins[0] = 0;

            for (int currentNumber = 1; currentNumber <= input; currentNumber++)
            {
                for (int currentCoin = 0; currentCoin < coins.Length; currentCoin++)
                {
                    if (currentNumber >= coins[currentCoin] && 1 + tempCoins[currentNumber - coins[currentCoin]] < tempCoins[currentNumber])
                    {
                        tempCoins[currentNumber] = tempCoins[currentNumber - coins[currentCoin]] + 1;
                    }
                }
            }
            return tempCoins[input];
        }

        public IEnumerable<string> GetCombinations(int[] set, int sum, string values)
        {
            for (int i = 0; i < set.Length; i++)
            {
                int left = sum - set[i];
                string vals = set[i] + "," + values;
                if (left == 0)
                {
                    yield return vals;
                }
                else
                {
                    int[] possible = set.Take(i).Where(n => n <= sum).ToArray();
                    if (possible.Length > 0)
                    {
                        foreach (string s in GetCombinations(possible, left, vals))
                        {
                            yield return s;
                        }
                    }
                }
            }
        }


        //public int findMatch(SortedDictionary<int, int> results,int check)
        //{
        //    int keyResult = 0;

        //    foreach (KeyValuePair<int, int> kvp in results.Where(x=>x.Key!=check).Reverse())
        //    {
        //        int _ret = 0;
        //        for (int i = 0;i< kvp.Value; i++)
        //        {
        //            _ret += kvp.Key;
        //            if (_ret == check)
        //            {
        //                break;
        //            }
        //        }
        //        //Console.WriteLine(kvp.Value);
        //        //Console.WriteLine(kvp.Key);
        //    }
        //    return keyResult;
        //}

        public static int FindChangeNum(int[] coins, int s)
        {
            int[] nums = Enumerable.Repeat(-1, s + 1).ToArray();
            nums[0] = 0;

            for (int i = 0; i < nums.Length; ++i)
            {
                foreach (int j in coins)
                {
                    if (i + j <= s)
                    {
                        if (nums[i] != -1 &&
                            nums[i + j] != -1)
                        {
                            nums[i + j] = Math.Min(nums[i] + 1, nums[i + j]);
                        }
                        else if (nums[i] != -1 &&
                            nums[i + j] == -1)
                        {
                            nums[i + j] = nums[i] + 1;
                        }
                    }
                }
            }

            return nums[s];
        }

        public Boolean isMatch(List<int> litOfCoin, int checkNum)
        {
            Boolean isMatch = false;


            if (litOfCoin.Contains(checkNum))
            {
                return true;
            }

            var indices = Enumerable.Range(0, litOfCoin.Count).ToArray();

            IEnumerable<IEnumerable<int>> result = StringExtensions.GetPermutations(Enumerable.Range(0, litOfCoin.Count), litOfCoin.Count);
            foreach (var item in result)
            {
                int tmp = 0;
                foreach (var _x in item)
                {

                    int coin = Convert.ToInt16(litOfCoin[_x]);
                    Console.WriteLine();
                    tmp += coin;
                    if (tmp == checkNum)
                    {
                        isMatch = true;
                        break;
                    }
                    Console.WriteLine();
                }
            }


            //for (int i = 0; i < litOfCoin.Count; i++)
            //{
            //    int coin = Convert.ToInt16(litOfCoin[i]);
            //    Console.WriteLine();
            //    tmp += coin;
            //    if (tmp == checkNum)
            //    {
            //        isMatch = true;
            //        break;
            //    }

            //}
            return isMatch;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            //0 1 3 0 3 1 1 4 3 2 3 3 2 4 2 3 4 4 | 0 1
            textBox6.Text = String.Empty;
            String[] datas = textBox1.Text.Split('|');
            String[] TOWNER = datas[1].Split(' ');
            String[] townList = datas[0].Split(' ');
            int result = 0;
            for (int i = 0; i < townList.Length - 3; i += 3)
            {
                String A = townList[i];
                String B = townList[i + 1];
                int C = Convert.ToInt16(townList[i + 2]);
                Boolean isss = false;
                if (TOWNER.Contains(B))
                {
                    result += C;
                    isss = true;
                }
                textBox6.Text += String.Format("{0}   {1}   {2}   {3}\r\n", townList[i], townList[i + 1], townList[i + 2], (isss) ? "*" : "");
                Console.WriteLine();
            }
            Console.WriteLine();
            textBox2.Text = result.ToString();
            Clipboard.SetText(textBox2.Text);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            int N = Convert.ToInt16(textBox1.Text.Split(' ')[0]);
            int K = Convert.ToInt16(textBox1.Text.Split(' ')[1]);
            String result = String.Join("", Enumerable.Range(1, N).ToArray());
            var array = Enumerable.Range(1, N).ToArray(); // { 1, 2, 3, 4, 5 } 
            int index = 1;
            Boolean isLoop = true;
            int resultValue = 1;
            while (isLoop)
            {
                array.Rotate(index);
                index++;
                if (index % K == 0)
                {
                    resultValue++;
                }
                String compare = String.Join("", array);
                if (result.Equals(compare))
                {
                    isLoop = false;
                }

            }
            textBox2.Text = resultValue.ToString();
            Clipboard.SetText(textBox2.Text);
            Console.WriteLine();
        }


        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Int64 K = Convert.ToInt64(textBox1.Text);
            Int64 result = 0;
            for (Int64 i = K; i < 1000000; i++)
            {
               Int64 tmp = i - Convert.ToInt64(String.Join("", i.ToString().ToCharArray().Reverse()));
                if (tmp == K)
                {
                    result = i;
                    break;
                }
            }

            textBox2.Text = (result==0)? "NONE":result.ToString();
            Clipboard.SetText(textBox2.Text);
        }
    }




}


public static class Algorithms
{
    public static void Rotate<T>(this T[] array, int count)
    {
        if (array == null || array.Length < 2) return;
        count %= array.Length;
        if (count == 0) return;
        int left = count < 0 ? -count : array.Length + count;
        int right = count > 0 ? count : array.Length - count;
        if (left <= right)
        {
            for (int i = 0; i < left; i++)
            {
                var temp = array[0];
                Array.Copy(array, 1, array, 0, array.Length - 1);
                array[array.Length - 1] = temp;
            }
        }
        else
        {
            for (int i = 0; i < right; i++)
            {
                var temp = array[array.Length - 1];
                Array.Copy(array, 0, array, 1, array.Length - 1);
                array[0] = temp;
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
    public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
    {
        if (length == 1) return list.Select(t => new T[] { t });

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (t1, t2) => t1.Concat(new T[] { t2 }));
    }

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

}