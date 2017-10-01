using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            textBox2.Text = result + "";
            Clipboard.SetText(textBox2.Text);
            Cursor = Cursors.Default;
            Console.WriteLine();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

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



        //public IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        //{
        //    if (s == null)
        //        throw new ArgumentNullException("s");
        //    if (partLength <= 0)
        //        throw new ArgumentException("Part length has to be positive.", "partLength");

        //    for (var i = 0; i < s.Length; i += partLength)
        //        yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        //}

        #endregion

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            textBox5.Text = (Convert.(textBox4.Text) * Convert.ToInt64(textBox3.Text))+"";
            Clipboard.SetText(textBox5.Text);
        }
    }
}

public class Q06Result
{
    public String word { get; set; }
    public int count { get; set; }
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
