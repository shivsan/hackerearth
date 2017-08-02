using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Solution
{
    public static void Main1()
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */

        var t = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            //var n = Convert.ToInt32(Console.ReadLine());
            var strList = Convert.ToString("a aa aaa aaaa aaaaa aaaaaa aaaaaaa aaaaaaaa aaaaaaaaa aaaaaaaaaa").Split(' ').ToList();
            var password = Convert.ToString("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            var prog = new PasswordCracker();
            prog.Words = strList;
            prog.Password = password;
            prog.PrintPassword();
        }

    }
}

public class PasswordCracker
{
    public List<string> Words { get; set; }

    public List<string> TrailWords { get; set; }

    public List<Tuple<string, bool>> memo = new List<Tuple<string, bool>>();

    private void GetSortedList()
    {
        Words.Sort(((x, y) => x.Length.CompareTo(y.Length)));
        //Words.Sort();
        Words.Reverse();
    }

    public PasswordCracker()
    {
        TrailWords = new List<string>();
    }

    public string Password;

    public void PrintPassword()
    {
        GetSortedList();
        //Console.WriteLine(PasswordCanBeMatched(Password)? TrailWords.Aggregate((a,b)=> a + " " + b) :"WRONG PASSWORD");
        Console.WriteLine(PasswordCanBeMatchedSort(Password) ? TrailWords.Aggregate((a, b) => a + " " + b) : "WRONG PASSWORD");
    }

    public bool PasswordCanBeMatchedSort(string password)
    {
        if(memo.FirstOrDefault(m=>m.Item1.Equals(password))!=null)
        {
            if (!memo.FirstOrDefault(m => m.Item1.Equals(password)).Item2)
                return false;
        }

        if (string.IsNullOrEmpty(password))
        {
            //memo.Add(new Tuple<string, bool>(password, false));
            return true;
        }

        if (!Words.Any(w => CustomContains(password, w)))
        {
            memo.Add(new Tuple<string, bool> (password, false));
            return false;
        }

        foreach (var word in Words.Where(w => CustomContains(password, w)))
        {
            TrailWords.Add(word);
            if (PasswordCanBeMatchedSort(RemoveFirst(password, word)))
                return true;

            TrailWords.RemoveAt(TrailWords.Count - 1);
        }

        memo.Add(new Tuple<string, bool>(password, false));
        return false;
    }

    public static string RemoveFirst(string source, string remove)
    {
        int index = source.IndexOf(remove);
        return (index < 0)
            ? source
            : source.Remove(index, remove.Length);
    }

    public bool CustomContains(string str, string sStr)
    {
        return (str.IndexOf(sStr)) == 0;

    }
}