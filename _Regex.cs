using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DrawEveything
{
    internal class _Regex
    {
         // id : tối thiểu 6 ký tự, có thể có chữ hoa,thường hoặc số 
        const string REGEX_ID = "^([0123456789]|[a-zA-Z]){6,18}$";
        // password :  tối thiểu 6 ký tự,phải có chữ hoa,thường, và số
        const string REGEX_PASSWORD = "^([a-z]|[A-Z]|[0123456789]){6,18}$";
        const string REGEX_CHAR_UP = "[A-Z]";
        const string REGEX_CHAR_LOWER = "[a-z]";
        const string REGEX_NUM = "[0123456789]";
        public bool Check_Format_Password(string input)
        {
            return Regex.IsMatch(input, REGEX_PASSWORD) && Regex.IsMatch(input, REGEX_CHAR_UP)
                && Regex.IsMatch(input, REGEX_CHAR_LOWER) && Regex.IsMatch(input, REGEX_NUM);
        }
        public bool Check_Format_User (string input)
        {
            return Regex.IsMatch(input, REGEX_ID);
        }
        
    }
}
