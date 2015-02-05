using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSA1SortedArray;
using NUnit.Framework;

namespace SortedArrayTests
{
    class SortedArrayPlayerUnitTests
    {
        private Dictionary<String, Player> _playersById;
        private Dictionary<int, string> _pidByNumber;

        [SetUp]
        public void Init()
        {
            _playersById = new Dictionary<String, Player>
            {
                {"Mbournival", new Player(49, "MICHAEL BOURNIVAL", "Forward")},
                {"Jrose", new Player(25, "JACOB DE LA ROSE", "Forward")},
                {"Ddesharnais", new Player(51, "DAVID DESHARNAIS", "Forward")},
                {"Gdumont", new Player(37, "GABRIEL DUMONT", "Forward")},
                {"Leller", new Player(81, "LARS ELLER", "Forward")},
                {"Agalchenyuk", new Player(27, "ALEX GALCHENYUK", "Forward")},
                {"Bgallagher", new Player(11, "BRENDAN GALLAGHER", "Forward")},
                {"Mmalhotra", new Player(20, "MANNY MALHOTRA", "Forward")},
                {"Mpacioretty", new Player(67, "MAX PACIORETTY", "Forward")},
                {"Pparenteau", new Player(15, "PIERRE-ALEXANDRE PARENTEAU", "Forward")},
                {"Tplekanec", new Player(14, "TOMAS PLEKANEC", "Forward")},
                {"Bprust", new Player(8, "BRANDON PRUST", "Forward")},
                {"Jsekac", new Player(26, "JIRI SEKAC", "Forward")},
                {"Cthomas", new Player(60, "CHRISTIAN THOMAS", "Forward")},
                {"Dweise", new Player(22, "DALE WEISE", "Forward")},
                {"Nbeaulieu", new Player(28, "NATHAN BEAULIEU", "Defencemen")},
                {"Aemelin", new Player(74, "ALEXEI EMELIN", "Defencemen")},
                {"Tgilbert", new Player(77, "TOM GILBERT", "Defencemen")},
                {"Sgonchar", new Player(55, "SERGEI GONCHAR", "Defencemen")},
                {"Amarkov", new Player(79, "ANDREI MARKOV", "Defencemen")},
                {"Psubban", new Player(76, "P.K. SUBBAN", "Defencemen")},
                {"Mweaver", new Player(43, "MIKE WEAVER", "Defencemen")},
                {"Cprice", new Player(31, "CAREY PRICE", "Goalie")},
                {"Dtokarski", new Player(35, "DUSTIN TOKARSKI", "Goalie")},
            };

            _pidByNumber = new Dictionary<int, string>(){
                {49, "Mbournival"},
                {25, "Jrose"},
                {51, "Ddesharnais"},
                {37, "Gdumont"},
                {81, "Leller"},
                {27, "Agalchenyuk"},
                {11, "Bgallagher"},
                {20, "Mmalhotra"},
                {67, "Mpacioretty"},
                {15, "Pparenteau"},
                {14, "Tplekanec"},
                {8, "Bprust"},
                {26, "Jsekac"},
                {60, "Cthomas"},
                {22, "Dweise"},
                {28, "Nbeaulieu"},
                {74, "Aemelin"},
                {77, "Tgilbert"},
                {55, "Sgonchar"},
                {79, "Amarkov"},
                {76, "Psubban"},
                {43, "Mweaver"},
                {31, "Cprice"},
                {35, "Dtokarski"},
            };
        }

        [TestCase(new[] { 26 }, 26, "JIRI SEKAC")]
        [TestCase(new[] { 26 }, 31, "CAREY PRICE", ExpectedException = typeof(KeyNotFoundException))]
        [TestCase(new[] { 31, 26, 8, 14 }, 8, "BRANDON PRUST")]
        public void InsertArrayThenFind(int[] players, int checkInt, String checkString)
        {
            var sa = new SortedArray<Player>(players.Length);
            foreach (var playerId in players)
            {
                sa.Insert(_playersById[_pidByNumber[playerId]]);
            }
            var findThisPlayer = new Player(checkInt, null, null);
            Assert.AreEqual(checkString, sa.Find(findThisPlayer).getPlayerName());
        }

        [TestCase(true, 0, new int[] { })]
        [TestCase(true, 4, new int[] { })]
        [TestCase(false, 4, new[] { 49 })]
        [TestCase(false, 4, new[] { 51, 49 })]
        [TestCase(false, 4, new[] { 25, 27, 37 })]
        public void TestEmpty(bool shouldBeEmpty, int arrSize, int[] players)
        {
            var sa = new SortedArray<Player>(arrSize);
            foreach (var playerId in players)
            {
                sa.Insert(_playersById[_pidByNumber[playerId]]);
            }
            Assert.AreEqual(shouldBeEmpty, sa.IsEmpty());
        }
    }
}
