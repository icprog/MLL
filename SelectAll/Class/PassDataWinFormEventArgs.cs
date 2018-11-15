using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Mulaolao.Class
{
    public class PassDataWinFormEventArgs : EventArgs
    {
        //

        private string _conOne;
        private string _conTwo;
        private string _conTre;
        private string _conFor;
        private string _conFiv;
        private string _conSix;
        private string _conSev;
        private string _conEgi;
        private string _conNin;
        private string _conTen;
        private string _conEleven;
        private string _conTwelve;
        private string _conThirteen;
        private string _conFourteen;
        private string _conFifteen;
        private string _conSixteen;
        public DataTable _tabOne;
        private List<string> _list;
        private Dictionary<string ,string> _dic;
        private int _id;


        public List<string> List
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
            }
        }
        public Dictionary<string ,string> Dic
        {
            get
            {
                return _dic;
            }
            set
            {
                _dic = value;
            }
        }
        public string ConOne
        {
            get { return _conOne; }
            set { _conOne = value; }
        }
        public string ConTwo
        {
            get { return _conTwo; }
            set { _conTwo = value; }
        }
        public string ConTre
        {
            get { return _conTre; }
            set { _conTre = value; }
        }
        public string ConFor
        {
            get { return _conFor; }
            set { _conFor = value; }
        }
        public string ConFiv
        {
            get { return _conFiv; }
            set { _conFiv = value; }
        }
        public string ConSix
        {
            get
            {
                return _conSix;
            }
            set
            {
                _conSix = value;
            }
        }
        public string ConSev
        {
            get
            {
                return _conSev;
            }
            set
            {
                _conSev = value;
            }
        }
        public string ConEgi
        {
            get
            {
                return _conEgi;
            }
            set
            {
                _conEgi = value;
            }
        }
        public string ConNin
        {
            get
            {
                return _conNin;
            }
            set
            {
                _conNin = value;
            }
        }
        public string ConTen
        {
            get
            {
                return _conTen;
            }
            set
            {
                _conTen = value;
            }
        }
        public string ConEleven
        {
            get
            {
                return _conEleven;
            }
            set
            {
                _conEleven = value;
            }
        }
        public string ConTwelve
        {
            get
            {
                return _conTwelve;
            }
            set
            {
                _conTwelve = value;
            }
        }
        public string ConThirteen
        {
            get
            {
                return _conThirteen;
            }
            set
            {
                _conThirteen = value;
            }
        }
        public string ConFourteen
        {
            get
            {
                return _conFourteen;
            }
            set
            {
                _conFourteen = value;
            }
        }
        public string ConFifteen
        {
            get
            {
                return _conFifteen;
            }
            set
            {
                _conFifteen = value;
            }
        }
        public string ConSixteen
        {
            get
            {
                return _conSixteen;
            }
            set
            {
                _conSixteen = value;
            }
        }
        public DataTable TabOne
        {
            get
            {
                return _tabOne;
            }
            set
            {
                _tabOne = value;
            }
        }
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public PassDataWinFormEventArgs()
        {
        }
        public PassDataWinFormEventArgs ( int Id)
        {
            this._id = Id;
        }
        public PassDataWinFormEventArgs (string conOne, Dictionary<string ,string> Dic )
        {
            this._conOne = conOne;
            this._dic = Dic;
        }
        public PassDataWinFormEventArgs (string conOne, List<string> List )
        {
            this._conOne = conOne;
            this._list = List;
        }
        public PassDataWinFormEventArgs ( List<string> List)
        {
            this._list = List;
        }
        public PassDataWinFormEventArgs(string conOne)
        {
            this._conOne = conOne;
        }
        public PassDataWinFormEventArgs( DataTable tabOne )
        {
            this._tabOne = tabOne;
        }
        public PassDataWinFormEventArgs ( string conOne ,DataTable tabOne )
        {
            this._conOne = conOne;
            this._tabOne = tabOne;
        }
        public PassDataWinFormEventArgs(string conOne,string conTwo)
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
        }
        public PassDataWinFormEventArgs ( string conOne ,string conTwo ,List<string> List )
        {
            this . _conOne = conOne;
            this . _conTwo = conTwo;
            this . _list = List;
        }
        public PassDataWinFormEventArgs(string conOne, string conTwo, string conTre)
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
        }
        public PassDataWinFormEventArgs ( string conOne ,string conTwo ,string conTre ,List<string> List )
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._list = List;
        }
        public PassDataWinFormEventArgs(string conOne, string conTwo, string conTre, string conFor)
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
        }
        public PassDataWinFormEventArgs ( string conOne ,string conTwo ,string conTre ,string conFor ,List<string> List )
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._list = List;
        }
        public PassDataWinFormEventArgs(string conOne, string conTwo, string conTre, string conFor, string conFiv)
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._conFiv = conFiv;
        }
        public PassDataWinFormEventArgs( string conOne, string conTwo, string conTre, string conFor, string conFiv,string conSix )
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._conFiv = conFiv;
            this._conSix = conSix;
        }
        public PassDataWinFormEventArgs( string conOne, string conTwo, string conTre, string conFor, string conFiv,string conSix,string conSev )
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._conFiv = conFiv;
            this._conSix = conSix;
            this._conSev = conSev;
        }
        public PassDataWinFormEventArgs( string conOne, string conTwo, string conTre, string conFor, string conFiv, string conSix, string conSev, string conEgi )
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._conFiv = conFiv;
            this._conSix = conSix;
            this._conSev = conSev;
            this._conEgi = conEgi;
        }
        public PassDataWinFormEventArgs( string conOne, string conTwo, string conTre, string conFor, string conFiv, string conSix, string conSev,string conEgi,string conNin )
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._conFiv = conFiv;
            this._conSix = conSix;
            this._conSev = conSev;
            this._conEgi = conEgi;
            this._conNin = conNin;
        }
        public PassDataWinFormEventArgs ( string conOne ,string conTwo ,string conTre ,string conFor ,string conFiv ,string conSix ,string conSev ,string conEgi ,string conNin,List<string> list )
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._conFiv = conFiv;
            this._conSix = conSix;
            this._conSev = conSev;
            this._conEgi = conEgi;
            this._conNin = conNin;
            this._list = list;
        }
        public PassDataWinFormEventArgs( string conOne, string conTwo, string conTre, string conFor, string conFiv, string conSix, string conSev, string conEgi, string conNin,string conTen )
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._conFiv = conFiv;
            this._conSix = conSix;
            this._conSev = conSev;
            this._conEgi = conEgi;
            this._conNin = conNin;
            this._conTen = conTen;
        }
        public PassDataWinFormEventArgs ( string conOne ,string conTwo ,string conTre ,string conFor ,string conFiv ,string conSix ,string conSev ,string conEgi ,string conNin ,string conTen ,string conEleven )
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._conFiv = conFiv;
            this._conSix = conSix;
            this._conSev = conSev;
            this._conEgi = conEgi;
            this._conNin = conNin;
            this._conTen = conTen;
            this._conEleven = conEleven;
        }
        public PassDataWinFormEventArgs( string conOne, string conTwo, string conTre, string conFor, string conFiv, string conSix, string conSev, string conEgi, string conNin, string conTen, string conEleven, string conTwelve)
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._conFiv = conFiv;
            this._conSix = conSix;
            this._conSev = conSev;
            this._conEgi = conEgi;
            this._conNin = conNin;
            this._conTen = conTen;
            this._conEleven = conEleven;
            this._conTwelve = conTwelve;
        }
        public PassDataWinFormEventArgs( string conOne, string conTwo, string conTre, string conFor, string conFiv, string conSix, string conSev, string conEgi, string conNin, string conTen, string conEleven, string conTwelve, string conThirteen)
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._conFiv = conFiv;
            this._conSix = conSix;
            this._conSev = conSev;
            this._conEgi = conEgi;
            this._conNin = conNin;
            this._conTen = conTen;
            this._conEleven = conEleven;
            this._conTwelve = conTwelve;
            this._conThirteen = conThirteen;
        }
        public PassDataWinFormEventArgs( string conOne, string conTwo, string conTre, string conFor, string conFiv, string conSix, string conSev, string conEgi, string conNin,string conTen,string conEleven,string conTwelve,string conThirteen,string conFourteen )
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._conFiv = conFiv;
            this._conSix = conSix;
            this._conSev = conSev;
            this._conEgi = conEgi;
            this._conNin = conNin;
            this._conTen = conTen;
            this._conEleven = conEleven;
            this._conTwelve = conTwelve;
            this._conThirteen = conThirteen;
            this._conFourteen = conFourteen;
        }
        public PassDataWinFormEventArgs ( string conOne ,string conTwo ,string conTre ,string conFor ,string conFiv ,string conSix ,string conSev ,string conEgi ,string conNin ,string conTen ,string conEleven ,string conTwelve ,string conThirteen ,string conFourteen,string conFifteen )
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._conFiv = conFiv;
            this._conSix = conSix;
            this._conSev = conSev;
            this._conEgi = conEgi;
            this._conNin = conNin;
            this._conTen = conTen;
            this._conEleven = conEleven;
            this._conTwelve = conTwelve;
            this._conThirteen = conThirteen;
            this._conFourteen = conFourteen;
            this._conFifteen = conFifteen;
        }
        public PassDataWinFormEventArgs ( string conOne ,string conTwo ,string conTre ,string conFor ,string conFiv ,string conSix ,string conSev ,string conEgi ,string conNin ,string conTen ,string conEleven ,string conTwelve ,string conThirteen ,string conFourteen ,string conFifteen ,string conSixteen)
        {
            this._conOne = conOne;
            this._conTwo = conTwo;
            this._conTre = conTre;
            this._conFor = conFor;
            this._conFiv = conFiv;
            this._conSix = conSix;
            this._conSev = conSev;
            this._conEgi = conEgi;
            this._conNin = conNin;
            this._conTen = conTen;
            this._conEleven = conEleven;
            this._conTwelve = conTwelve;
            this._conThirteen = conThirteen;
            this._conFourteen = conFourteen;
            this._conFifteen = conFifteen;
            this._conSixteen = conSixteen;
        }

    }  
}
