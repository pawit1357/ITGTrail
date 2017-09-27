using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ITGTRAIL
{
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


            textBox2.Text = (rawDat.Length - ((xxx.Count==0)? 2: (xxx.Count == 1 ? 1 : 0))).ToString();
            Clipboard.SetText(textBox2.Text);
            Cursor = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            char[] inValueChar = textBox1.Text.ToCharArray();
            Hashtable hashtable = new Hashtable();


            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                for (int j = 0; j < textBox1.Text.Length - 2; j++)
                {
                    String w1 = textBox1.Text.Remove(i, 1);
                    String w2 = w1.Remove(j, 1);
                    if (!hashtable.Contains(w2))
                    {
                        hashtable.Add(w2, w2);
                    }
                }
            }


            textBox2.Text = (hashtable.Count + 1) + "";
            Clipboard.SetText(textBox2.Text);
            Cursor = Cursors.Default;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            String[] times = textBox1.Text.Split(' ');


            List<String> listOfResult = new List<string>();

            foreach (String p in times)
            {
                //
                List<int> selectedLists = new List<int>();
                bool user = true;//true=T,false=R
                //
                int rangeLimit = Convert.ToInt16(p);
                List<int> lstOfNmbs = listOfNmb(rangeLimit);

                Boolean isLoop = true;
                while (isLoop)
                {
                    int matchValue = lstOfNmbs.Where(x => IsPrime(x) && !selectedLists.Contains(x)).FirstOrDefault();
                    if (matchValue != 0)
                    {
                        selectedLists.Add(matchValue);
                        int mulValue = matchValue * matchValue;
                        int matchMulVal = lstOfNmbs.Where(x => x == mulValue).FirstOrDefault();
                        if (matchMulVal != 0)
                        {
                            selectedLists.Add(mulValue);
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        if (user)//T
                        {
                            listOfResult.Add("R");
                        }
                        else//R
                        {
                            listOfResult.Add("T");
                        }
                        isLoop = false;

                    }
                    user = !user;
                    Console.WriteLine();

                }
            }
            textBox2.Text = "";
            textBox2.Text = string.Join(" ", listOfResult);
            Clipboard.SetText(textBox2.Text);
            Cursor = Cursors.Default;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            /*
Ques#10 (2 4 6 - 10 1 1)
2 4 6
3 3 6
4 2 6
4 3 5
5 2 5
5 3 4
6 2 4
6 3 2
7 2 2
7 3 1
8 2 1
9 1 1
             */
            Cursor = Cursors.WaitCursor;
            String[] data = textBox1.Text.Split('-');
            String[] start = data[0].Substring(0, data[0].Length - 1).Split(' ');
            String[] finish = data[1].Substring(1, data[1].Length - 1).Split(' ');

            int count = 0;
            int pos = 0;

            while (pos < start.Length)
            {
                int _s = Convert.ToInt16(start[pos]);
                int _f = Convert.ToInt16(finish[pos]);
                while (_s > _f)
                {
                    start[pos] = (Convert.ToInt16(start[pos]) - 1).ToString();
                    start[pos + 1] = (Convert.ToInt16(start[pos + 1]) + 1).ToString();
                    _s = Convert.ToInt16(start[pos]);
                    _f = Convert.ToInt16(finish[pos]);
                    count++;
                }
                pos++;
                Console.WriteLine();
            }

            textBox2.Text = count.ToString();
            Clipboard.SetText(textBox2.Text);
            Cursor = Cursors.Default;
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

}
