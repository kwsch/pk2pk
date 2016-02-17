using System;
using System.IO;
using System.Linq;

namespace pk2pk
{
    public class PKX
    {
        // C# PKX Function Library
        // No WinForm object related code, only to calculate information.
        // May require re-referencing to main form for string array referencing.
        // Relies on Util for some common operations.

        // Data
        internal static uint LCRNG(uint seed)
        {
            const uint a = 0x41C64E6D;
            const uint c = 0x00006073;

            return seed * a + c;
        }
        internal static uint LCRNG(ref uint seed)
        {
            const uint a = 0x41C64E6D;
            const uint c = 0x00006073;

            return seed = seed * a + c;
        }
        #region ExpTable
        internal static readonly uint[,] ExpTable =
        {
            {0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0},
            {8, 15, 4, 9, 6, 10},
            {27, 52, 13, 57, 21, 33},
            {64, 122, 32, 96, 51, 80},
            {125, 237, 65, 135, 100, 156},
            {216, 406, 112, 179, 172, 270},
            {343, 637, 178, 236, 274, 428},
            {512, 942, 276, 314, 409, 640},
            {729, 1326, 393, 419, 583, 911},
            {1000, 1800, 540, 560, 800, 1250},
            {1331, 2369, 745, 742, 1064, 1663},
            {1728, 3041, 967, 973, 1382, 2160},
            {2197, 3822, 1230, 1261, 1757, 2746},
            {2744, 4719, 1591, 1612, 2195, 3430},
            {3375, 5737, 1957, 2035, 2700, 4218},
            {4096, 6881, 2457, 2535, 3276, 5120},
            {4913, 8155, 3046, 3120, 3930, 6141},
            {5832, 9564, 3732, 3798, 4665, 7290},
            {6859, 11111, 4526, 4575, 5487, 8573},
            {8000, 12800, 5440, 5460, 6400, 10000},
            {9261, 14632, 6482, 6458, 7408, 11576},
            {10648, 16610, 7666, 7577, 8518, 13310},
            {12167, 18737, 9003, 8825, 9733, 15208},
            {13824, 21012, 10506, 10208, 11059, 17280},
            {15625, 23437, 12187, 11735, 12500, 19531},
            {17576, 26012, 14060, 13411, 14060, 21970},
            {19683, 28737, 16140, 15244, 15746, 24603},
            {21952, 31610, 18439, 17242, 17561, 27440},
            {24389, 34632, 20974, 19411, 19511, 30486},
            {27000, 37800, 23760, 21760, 21600, 33750},
            {29791, 41111, 26811, 24294, 23832, 37238},
            {32768, 44564, 30146, 27021, 26214, 40960},
            {35937, 48155, 33780, 29949, 28749, 44921},
            {39304, 51881, 37731, 33084, 31443, 49130},
            {42875, 55737, 42017, 36435, 34300, 53593},
            {46656, 59719, 46656, 40007, 37324, 58320},
            {50653, 63822, 50653, 43808, 40522, 63316},
            {54872, 68041, 55969, 47846, 43897, 68590},
            {59319, 72369, 60505, 52127, 47455, 74148},
            {64000, 76800, 66560, 56660, 51200, 80000},
            {68921, 81326, 71677, 61450, 55136, 86151},
            {74088, 85942, 78533, 66505, 59270, 92610},
            {79507, 90637, 84277, 71833, 63605, 99383},
            {85184, 95406, 91998, 77440, 68147, 106480},
            {91125, 100237, 98415, 83335, 72900, 113906},
            {97336, 105122, 107069, 89523, 77868, 121670},
            {103823, 110052, 114205, 96012, 83058, 129778},
            {110592, 115015, 123863, 102810, 88473, 138240},
            {117649, 120001, 131766, 109923, 94119, 147061},
            {125000, 125000, 142500, 117360, 100000, 156250},
            {132651, 131324, 151222, 125126, 106120, 165813},
            {140608, 137795, 163105, 133229, 112486, 175760},
            {148877, 144410, 172697, 141677, 119101, 186096},
            {157464, 151165, 185807, 150476, 125971, 196830},
            {166375, 158056, 196322, 159635, 133100, 207968},
            {175616, 165079, 210739, 169159, 140492, 219520},
            {185193, 172229, 222231, 179056, 148154, 231491},
            {195112, 179503, 238036, 189334, 156089, 243890},
            {205379, 186894, 250562, 199999, 164303, 256723},
            {216000, 194400, 267840, 211060, 172800, 270000},
            {226981, 202013, 281456, 222522, 181584, 283726},
            {238328, 209728, 300293, 234393, 190662, 297910},
            {250047, 217540, 315059, 246681, 200037, 312558},
            {262144, 225443, 335544, 259392, 209715, 327680},
            {274625, 233431, 351520, 272535, 219700, 343281},
            {287496, 241496, 373744, 286115, 229996, 359370},
            {300763, 249633, 390991, 300140, 240610, 375953},
            {314432, 257834, 415050, 314618, 251545, 393040},
            {328509, 267406, 433631, 329555, 262807, 410636},
            {343000, 276458, 459620, 344960, 274400, 428750},
            {357911, 286328, 479600, 360838, 286328, 447388},
            {373248, 296358, 507617, 377197, 298598, 466560},
            {389017, 305767, 529063, 394045, 311213, 486271},
            {405224, 316074, 559209, 411388, 324179, 506530},
            {421875, 326531, 582187, 429235, 337500, 527343},
            {438976, 336255, 614566, 447591, 351180, 548720},
            {456533, 346965, 639146, 466464, 365226, 570666},
            {474552, 357812, 673863, 485862, 379641, 593190},
            {493039, 367807, 700115, 505791, 394431, 616298},
            {512000, 378880, 737280, 526260, 409600, 640000},
            {531441, 390077, 765275, 547274, 425152, 664301},
            {551368, 400293, 804997, 568841, 441094, 689210},
            {571787, 411686, 834809, 590969, 457429, 714733},
            {592704, 423190, 877201, 613664, 474163, 740880},
            {614125, 433572, 908905, 636935, 491300, 767656},
            {636056, 445239, 954084, 660787, 508844, 795070},
            {658503, 457001, 987754, 685228, 526802, 823128},
            {681472, 467489, 1035837, 710266, 545177, 851840},
            {704969, 479378, 1071552, 735907, 563975, 881211},
            {729000, 491346, 1122660, 762160, 583200, 911250},
            {753571, 501878, 1160499, 789030, 602856, 941963},
            {778688, 513934, 1214753, 816525, 622950, 973360},
            {804357, 526049, 1254796, 844653, 643485, 1005446},
            {830584, 536557, 1312322, 873420, 664467, 1038230},
            {857375, 548720, 1354652, 902835, 685900, 1071718},
            {884736, 560922, 1415577, 932903, 707788, 1105920},
            {912673, 571333, 1460276, 963632, 730138, 1140841},
            {941192, 583539, 1524731, 995030, 752953, 1176490},
            {970299, 591882, 1571884, 1027103, 776239, 1212873},
            {1000000, 600000, 1640000, 1059860, 800000, 1250000},
        };
        #endregion

        internal static readonly string[][] SpeciesLang = 
        {
            Util.getStringList("Species", "ja"), // none
            Util.getStringList("Species", "ja"), // 1
            Util.getStringList("Species", "en"), // 2
            Util.getStringList("Species", "fr"), // 3
            Util.getStringList("Species", "it"), // 4
            Util.getStringList("Species", "de"), // 5
            Util.getStringList("Species", "es"), // none
            Util.getStringList("Species", "es"), // 7
            Util.getStringList("Species", "ko"), // 8
        };

        internal static string getSpeciesName(int species, int lang)
        {
            try { return SpeciesLang[lang][species]; }
            catch { return ""; }
        }
        internal static readonly PersonalInfo[] Personal = getPersonalArray(Properties.Resources.personal);
        internal static PersonalInfo[] getPersonalArray(byte[] data)
        {
            PersonalInfo[] d = new PersonalInfo[data.Length / PersonalInfo.Size];
            for (int i = 0; i < d.Length; i++)
                d[i] = new PersonalInfo(data.Skip(i*PersonalInfo.Size).Take(PersonalInfo.Size).ToArray());
            return d;
        }

        // Stat Fetching
        internal static int getMovePP(int move, int ppup)
        {
            return getBasePP(move) * (5 + ppup) / 5;
        }
        internal static int getBasePP(int move)
        {
            byte[] movepptable = 
            {
	            00, 
	            35, 25, 10, 15, 20, 20, 15, 15, 15, 35, 30, 05, 10, 20, 30, 35, 35, 20, 15, 20, 
	            20, 25, 20, 30, 05, 10, 15, 15, 15, 25, 20, 05, 35, 15, 20, 20, 10, 15, 30, 35, 
	            20, 20, 30, 25, 40, 20, 15, 20, 20, 20, 30, 25, 15, 30, 25, 05, 15, 10, 05, 20, 
	            20, 20, 05, 35, 20, 25, 20, 20, 20, 15, 25, 15, 10, 20, 25, 10, 35, 30, 15, 10, 
	            40, 10, 15, 30, 15, 20, 10, 15, 10, 05, 10, 10, 25, 10, 20, 40, 30, 30, 20, 20, 
	            15, 10, 40, 15, 10, 30, 10, 20, 10, 40, 40, 20, 30, 30, 20, 30, 10, 10, 20, 05, 
	            10, 30, 20, 20, 20, 05, 15, 10, 20, 10, 15, 35, 20, 15, 10, 10, 30, 15, 40, 20, 
	            15, 10, 05, 10, 30, 10, 15, 20, 15, 40, 20, 10, 05, 15, 10, 10, 10, 15, 30, 30, 
	            10, 10, 20, 10, 01, 01, 10, 25, 10, 05, 15, 25, 15, 10, 15, 30, 05, 40, 15, 10, 
	            25, 10, 30, 10, 20, 10, 10, 10, 10, 10, 20, 05, 40, 05, 05, 15, 05, 10, 05, 10, 
	            10, 10, 10, 20, 20, 40, 15, 10, 20, 20, 25, 05, 15, 10, 05, 20, 15, 20, 25, 20, 
	            05, 30, 05, 10, 20, 40, 05, 20, 40, 20, 15, 35, 10, 05, 05, 05, 15, 05, 20, 05, 
	            05, 15, 20, 10, 05, 05, 15, 10, 15, 15, 10, 10, 10, 20, 10, 10, 10, 10, 15, 15, 
	            15, 10, 20, 20, 10, 20, 20, 20, 20, 20, 10, 10, 10, 20, 20, 05, 15, 10, 10, 15, 
	            10, 20, 05, 05, 10, 10, 20, 05, 10, 20, 10, 20, 20, 20, 05, 05, 15, 20, 10, 15, 
	            20, 15, 10, 10, 15, 10, 05, 05, 10, 15, 10, 05, 20, 25, 05, 40, 15, 05, 40, 15, 
	            20, 20, 05, 15, 20, 20, 15, 15, 05, 10, 30, 20, 30, 15, 05, 40, 15, 05, 20, 05, 
	            15, 25, 25, 15, 20, 15, 20, 15, 20, 10, 20, 20, 05, 05, 10, 05, 40, 10, 10, 05, 
	            10, 10, 15, 10, 20, 15, 30, 10, 20, 05, 10, 10, 15, 10, 10, 05, 15, 05, 10, 10, 
	            30, 20, 20, 10, 10, 05, 05, 10, 05, 20, 10, 20, 10, 15, 10, 20, 20, 20, 15, 15, 
	            10, 15, 15, 15, 10, 10, 10, 20, 10, 30, 05, 10, 15, 10, 10, 05, 20, 30, 10, 30, 
	            15, 15, 15, 15, 30, 10, 20, 15, 10, 10, 20, 15, 05, 05, 15, 15, 05, 10, 05, 20, 
	            05, 15, 20, 05, 20, 20, 20, 20, 10, 20, 10, 15, 20, 15, 10, 10, 05, 10, 05, 05, 
	            10, 05, 05, 10, 05, 05, 05, 15, 10, 10, 10, 10, 10, 10, 15, 20, 15, 10, 15, 10, 
	            15, 10, 20, 10, 15, 10, 20, 20, 20, 20, 20, 15, 15, 15, 15, 15, 15, 20, 15, 10, 
	            15, 15, 15, 15, 10, 10, 10, 10, 10, 15, 15, 15, 15, 05, 05, 15, 05, 10, 10, 10, 
	            20, 20, 20, 10, 10, 30, 15, 15, 10, 15, 25, 10, 15, 10, 10, 10, 20, 10, 10, 10, 
	            10, 10, 15, 15, 05, 05, 10, 10, 10, 05, 05, 10, 05, 05, 15, 10, 05, 05, 05, 10, 
	            10, 10, 10, 20, 25, 10, 20, 30, 25, 20, 20, 15, 20, 15, 20, 20, 10, 10, 10, 10, 
	            10, 20, 10, 30, 15, 10, 10, 10, 20, 20, 05, 05, 05, 20, 10, 10, 20, 15, 20, 20, 
	            10, 20, 30, 10, 10, 40, 40, 30, 20, 40, 20, 20, 10, 10, 10, 10, 05, 10, 10, 05, 
	            05 
            };
            if (move < 0) move = 0;
            return movepptable[move];
        }
        internal static byte[] getRandomEVs()
        {
            byte[] evs = new byte[6];
            do {
                evs[0] = (byte)Math.Min(Util.rnd32() % 300, 252); // bias two to get maybe 252
                evs[1] = (byte)Math.Min(Util.rnd32() % 300, 252);
                evs[2] = (byte)Math.Min(Util.rnd32() % (510 - evs[0] - evs[1]), 252);
                evs[3] = (byte)Math.Min(Util.rnd32() % (510 - evs[0] - evs[1] - evs[2]), 252);
                evs[4] = (byte)Math.Min(Util.rnd32() % (510 - evs[0] - evs[1] - evs[2] - evs[3]), 252);
                evs[5] = (byte)Math.Min(510 - evs[0] - evs[1] - evs[2] - evs[3] - evs[4], 252);
            } while (evs.Sum(b => b) > 510); // recalculate random EVs...
            Util.Shuffle(evs);
            return evs;
        }
        internal static byte getBaseFriendship(int species)
        {
            return Personal[species].BaseFriendship;
        }
        internal static int getLevel(int species, uint exp)
        {
            if (exp == 0) return 1;

            int growth = Personal[species].EXPGrowth;

            // Iterate upwards to find the level above our current level
            int tl = 0; // Initial Level, immediately incremented before loop.
            while (ExpTable[++tl, growth] <= exp)
            {
                if (tl != 100) continue;
                return 100;
                // After we find the level above ours, we're done.
            }
            return --tl;
        }
        internal static bool getIsShiny(uint PID, uint TID, uint SID)
        {
            uint PSV = getPSV(PID);
            uint TSV = getTSV(TID, SID);
            return TSV == PSV;
        }
        internal static uint getEXP(int level, int species)
        {
            // Fetch Growth
            if (level <= 1) return 0;
            if (level > 100) level = 100;
            return ExpTable[level, Personal[species].EXPGrowth];
        }
        internal static byte[] getAbilities(int species, int formnum)
        {
            return Personal[Personal[species].FormeIndex(species, formnum)].Abilities;
        }
        internal static int getAbilityNumber(int species, int ability, int formnum)
        {
            byte[] spec_abilities = Personal[Personal[species].FormeIndex(species, formnum)].Abilities;
            int abilval = Array.IndexOf(spec_abilities, (byte)ability);
            if (abilval >= 0)
                return 1 << abilval;
            return -1;
        }

        internal static string[] getCountryRegionText(int country, int region, string lang)
        {
            // Get Language we're fetching for
            int index = Array.IndexOf(new[] { "ja", "en", "fr", "de", "it", "es", "zh", "ko"}, lang);
            // Return value storage
            string[] data = new string[2]; // country, region

            // Get Country Text
            try
            {
                string[] inputCSV = Util.getStringList("countries");
                // Set up our Temporary Storage
                string[] unsortedList = new string[inputCSV.Length - 1];
                int[] indexes = new int[inputCSV.Length - 1];

                // Gather our data from the input file
                for (int i = 1; i < inputCSV.Length; i++)
                {
                    string[] countryData = inputCSV[i].Split(',');
                    if (countryData.Length <= 1) continue;
                    indexes[i - 1] = Convert.ToInt32(countryData[0]);
                    unsortedList[i - 1] = countryData[index + 1];
                }

                int countrynum = Array.IndexOf(indexes, country);
                data[0] = unsortedList[countrynum];
            }
            catch { data[0] = "Illegal"; }

            // Get Region Text
            try
            {
                string[] inputCSV = Util.getStringList("sr_" + country.ToString("000"));
                // Set up our Temporary Storage
                string[] unsortedList = new string[inputCSV.Length - 1];
                int[] indexes = new int[inputCSV.Length - 1];

                // Gather our data from the input file
                for (int i = 1; i < inputCSV.Length; i++)
                {
                    string[] countryData = inputCSV[i].Split(',');
                    if (countryData.Length <= 1) continue;
                    indexes[i - 1] = Convert.ToInt32(countryData[0]);
                    unsortedList[i - 1] = countryData[index + 1];
                }

                int regionnum = Array.IndexOf(indexes, region);
                data[1] = unsortedList[regionnum];
            }
            catch { data[1] = "Illegal"; }
            return data;
        }
        internal static string getFileName(PK6 pk6)
        {
            return
                $"{pk6.Species.ToString("000")}{(pk6.IsShiny ? " ★" : "")} - {pk6.Nickname} - {pk6.Checksum.ToString("X4")}{pk6.EncryptionConstant.ToString("X8")}.pk6";
        }
        internal static ushort[] getStats(PK6 pk6)
        {
            return getStats(pk6.Species, pk6.Stat_Level, pk6.Nature, pk6.AltForm,
                pk6.EV_HP, pk6.EV_ATK, pk6.EV_DEF, pk6.EV_SPA, pk6.EV_SPD, pk6.EV_SPE,
                pk6.IV_HP, pk6.IV_ATK, pk6.IV_DEF, pk6.IV_SPA, pk6.IV_SPD, pk6.IV_SPE);
        }
        internal static ushort[] getStats(int species, int level, int nature, int form,
                                        int HP_EV, int ATK_EV, int DEF_EV, int SPA_EV, int SPD_EV, int SPE_EV,
                                        int HP_IV, int ATK_IV, int DEF_IV, int SPA_IV, int SPD_IV, int SPE_IV)
        {
            PersonalInfo p = Personal[Personal[species].FormeIndex(species, form)];
            int HP_B = p.HP;
            int ATK_B = p.ATK;
            int DEF_B = p.DEF;
            int SPE_B = p.SPE;
            int SPA_B = p.SPA;
            int SPD_B = p.SPD;

            // Calculate Stats
            ushort[] stats = new ushort[6]; // Stats are stored as ushorts in the PKX structure. We'll cap them as such.
            stats[0] = (ushort)(HP_B == 1 ? 1 : (HP_IV + 2 * HP_B + HP_EV / 4 + 100) * level / 100 + 10);
            stats[1] = (ushort)((ATK_IV + 2 * ATK_B + ATK_EV / 4) * level / 100 + 5);
            stats[2] = (ushort)((DEF_IV + 2 * DEF_B + DEF_EV / 4) * level / 100 + 5);
            stats[4] = (ushort)((SPA_IV + 2 * SPA_B + SPA_EV / 4) * level / 100 + 5);
            stats[5] = (ushort)((SPD_IV + 2 * SPD_B + SPD_EV / 4) * level / 100 + 5);
            stats[3] = (ushort)((SPE_IV + 2 * SPE_B + SPE_EV / 4) * level / 100 + 5);

            // Account for nature
            int incr = nature / 5 + 1;
            int decr = nature % 5 + 1;
            if (incr == decr) return stats; // if neutral return stats without mod
            stats[incr] *= 11; stats[incr] /= 10;
            stats[decr] *= 9; stats[decr] /= 10;

            // Return Result
            return stats;
        }


        // PKX Manipulation
        internal static readonly byte[][] blockPosition =
        {
            new byte[] {0, 0, 0, 0, 0, 0, 1, 1, 2, 3, 2, 3, 1, 1, 2, 3, 2, 3, 1, 1, 2, 3, 2, 3},
            new byte[] {1, 1, 2, 3, 2, 3, 0, 0, 0, 0, 0, 0, 2, 3, 1, 1, 3, 2, 2, 3, 1, 1, 3, 2},
            new byte[] {2, 3, 1, 1, 3, 2, 2, 3, 1, 1, 3, 2, 0, 0, 0, 0, 0, 0, 3, 2, 3, 2, 1, 1},
            new byte[] {3, 2, 3, 2, 1, 1, 3, 2, 3, 2, 1, 1, 3, 2, 3, 2, 1, 1, 0, 0, 0, 0, 0, 0},
        };
        internal static readonly byte[] blockPositionInvert =
        {
            0, 1, 2, 4, 3, 5, 6, 7, 12, 18, 13, 19, 8, 10, 14, 20, 16, 22, 9, 11, 15, 21, 17, 23
        };
        internal static byte[] shuffleArray(byte[] data, uint sv)
        {
            byte[] sdata = new byte[260];
            Array.Copy(data, sdata, 8); // Copy unshuffled bytes

            // Shuffle Away!
            for (int block = 0; block < 4; block++)
                Array.Copy(data, 8 + 56*blockPosition[block][sv], sdata, 8 + 56*block, 56);

            // Fill the Battle Stats back
            if (data.Length > 232)
                Array.Copy(data, 232, sdata, 232, 28);

            return sdata;
        }
        internal static byte[] decryptArray(byte[] ekx)
        {
            byte[] pkx = (byte[])ekx.Clone();

            uint pv = BitConverter.ToUInt32(pkx, 0);
            uint sv = (pv >> 0xD & 0x1F) % 24;

            uint seed = pv;

            // Decrypt Blocks with RNG Seed
            for (int i = 8; i < 232; i += 2)
                BitConverter.GetBytes((ushort)(BitConverter.ToUInt16(pkx, i) ^ LCRNG(ref seed) >> 16)).CopyTo(pkx, i);

            // Deshuffle
            pkx = shuffleArray(pkx, sv);

            // Decrypt the Party Stats
            seed = pv;
            if (pkx.Length <= 232) return pkx;
            for (int i = 232; i < 260; i += 2)
                BitConverter.GetBytes((ushort)(BitConverter.ToUInt16(pkx, i) ^ LCRNG(ref seed) >> 16)).CopyTo(pkx, i);

            return pkx;
        }
        internal static byte[] encryptArray(byte[] pkx)
        {
            // Shuffle
            uint pv = BitConverter.ToUInt32(pkx, 0);
            uint sv = (pv >> 0xD & 0x1F) % 24;

            byte[] ekx = (byte[])pkx.Clone();

            ekx = shuffleArray(ekx, blockPositionInvert[sv]);

            uint seed = pv;

            // Encrypt Blocks with RNG Seed
            for (int i = 8; i < 232; i += 2)
                BitConverter.GetBytes((ushort)(BitConverter.ToUInt16(ekx, i) ^ LCRNG(ref seed) >> 16)).CopyTo(ekx, i);

            // If no party stats, return.
            if (ekx.Length <= 232) return ekx;

            // Encrypt the Party Stats
            seed = pv;
            for (int i = 232; i < 260; i += 2)
                BitConverter.GetBytes((ushort)(BitConverter.ToUInt16(ekx, i) ^ LCRNG(ref seed) >> 16)).CopyTo(ekx, i);

            // Done
            return ekx;
        }
        internal static bool verifychk(byte[] input)
        {
            ushort checksum = 0;
            if (input.Length == 100 || input.Length == 80)  // Gen 3 Files
            {
                for (int i = 32; i < 80; i += 2)
                    checksum += BitConverter.ToUInt16(input, i);

                return checksum == BitConverter.ToUInt16(input, 28);
            }
            {
                if (input.Length == 236 || input.Length == 220 || input.Length == 136) // Gen 4/5
                    Array.Resize(ref input, 136);
                else if (input.Length == 232 || input.Length == 260) // Gen 6
                    Array.Resize(ref input, 232);
                else throw new Exception("Wrong sized input array to verifychecksum");

                ushort chk = 0;
                for (int i = 8; i < input.Length; i += 2)
                    chk += BitConverter.ToUInt16(input, i);

                return chk == BitConverter.ToUInt16(input, 0x6);
            }
        }
        internal static uint getPSV(uint PID)
        {
            return Convert.ToUInt16((PID >> 16 ^ PID & 0xFFFF) >> 4);
        }
        internal static uint getTSV(uint TID, uint SID)
        {
            return (TID ^ SID) >> 4;
        }
        
        public class PersonalInfo
        {
            internal static int Size = 0x50;
            public byte HP, ATK, DEF, SPE, SPA, SPD;
            public int BST;
            public int EV_HP, EV_ATK, EV_DEF, EV_SPE, EV_SPA, EV_SPD;
            public byte[] Types = new byte[2];
            public byte CatchRate, EvoStage;
            public ushort[] Items = new ushort[3];
            public byte Gender, HatchCycles, BaseFriendship, EXPGrowth;
            public byte[] EggGroups = new byte[2];
            public byte[] Abilities = new byte[3];
            public ushort FormStats, FormeSprite, BaseEXP;
            public byte FormeCount, Color;
            public float Height, Weight;
            public bool[] TMHM;
            public bool[] Tutors;
            public bool[][] ORASTutors = new bool[4][];
            public byte EscapeRate;
            
            public PersonalInfo(byte[] data)
            {
                using (BinaryReader br = new BinaryReader(new MemoryStream(data)))
                {
                    HP = br.ReadByte(); ATK = br.ReadByte(); DEF = br.ReadByte();
                    SPE = br.ReadByte(); SPA = br.ReadByte(); SPD = br.ReadByte();
                    BST = HP + ATK + DEF + SPE + SPA + SPD;

                    Types = new[] { br.ReadByte(), br.ReadByte() };
                    CatchRate = br.ReadByte();
                    EvoStage = br.ReadByte();

                    ushort EVs = br.ReadUInt16();
                    EV_HP = EVs >> 0 & 0x3;
                    EV_ATK = EVs >> 2 & 0x3;
                    EV_DEF = EVs >> 4 & 0x3;
                    EV_SPE = EVs >> 6 & 0x3;
                    EV_SPA = EVs >> 8 & 0x3;
                    EV_SPD = EVs >> 10 & 0x3;

                    Items = new[] { br.ReadUInt16(), br.ReadUInt16(), br.ReadUInt16() };
                    Gender = br.ReadByte();
                    HatchCycles = br.ReadByte();
                    BaseFriendship = br.ReadByte();

                    EXPGrowth = br.ReadByte();
                    EggGroups = new[] { br.ReadByte(), br.ReadByte() };
                    Abilities = new[] { br.ReadByte(), br.ReadByte(), br.ReadByte() };
                    EscapeRate = br.ReadByte();
                    FormStats = br.ReadUInt16();

                    FormeSprite = br.ReadUInt16();
                    FormeCount = br.ReadByte();
                    Color = br.ReadByte();
                    BaseEXP = br.ReadUInt16();

                    Height = br.ReadUInt16();
                    Weight = br.ReadUInt16();

                    byte[] TMHMData = br.ReadBytes(0x10);
                    TMHM = new bool[8 * TMHMData.Length];
                    for (int j = 0; j < TMHM.Length; j++)
                        TMHM[j] = (TMHMData[j / 8] >> (j % 8) & 0x1) == 1; //Bitflags for TMHM

                    byte[] TutorData = br.ReadBytes(8);
                    Tutors = new bool[8 * TutorData.Length];
                    for (int j = 0; j < Tutors.Length; j++)
                        Tutors[j] = (TutorData[j / 8] >> (j % 8) & 0x1) == 1; //Bitflags for Tutors

                    if (br.BaseStream.Length - br.BaseStream.Position == 0x10) // ORAS
                    {
                        byte[][] ORASTutorData =
                        {
                            br.ReadBytes(2), // 15
                            br.ReadBytes(3), // 17
                            br.ReadBytes(2), // 16
                            br.ReadBytes(2), // 15
                        };
                        for (int i = 0; i < 4; i++)
                        {
                            ORASTutors[i] = new bool[8 * ORASTutorData[i].Length];
                            for (int b = 0; b < 8 * ORASTutorData[i].Length; b++)
                                ORASTutors[i][b] = (ORASTutorData[i][b / 8] >> b % 8 & 0x1) == 1;
                        }
                    }
                }
            }

            // Data Manipulation
            public int FormeIndex(int species, int forme)
            {
                return forme == 0 || FormStats == 0 ? species : FormStats + forme - 1;
            }
            public int RandomGender
            {
                get
                {
                    switch (Gender)
                    {
                        case 255: // Genderless
                            return 2;
                        case 254: // Female
                            return 1;
                        case 0: // Male
                            return 0;
                        default:
                            return (int)(Util.rnd32()%2);
                    }
                }
            }
            public bool HasFormes => FormeCount > 1;
        }
    }
}
