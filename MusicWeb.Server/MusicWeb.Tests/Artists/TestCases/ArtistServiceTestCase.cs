using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Tests.Artists.TestCases
{
    public class ArtistServiceTestCase
    {
        public static readonly List<object[]> ArtistArgumentExceptionTestCase = new List<object[]>
        { //string Name, Games Enum
            new object[]{ "test", DateTime.Now, -2},
            new object[]{ "", 0},
            new object[]{ "    ", 0},
        };

        public static IEnumerable<object[]> ArtistArgumentExceptionIndex
        {
            get
            {
                List<object[]> tmp = new List<object[]>();
                for (int i = 0; i < ArtistArgumentExceptionTestCase.Count; i++)
                    tmp.Add(new object[] { i });
                return tmp;
            }
        }
    }
}
