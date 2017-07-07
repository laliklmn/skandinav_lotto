using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skandinav_lotto_20170623

{
    class Program
    {
        static int Szamolo_2(int[,] sorsolasok, int sorSzamolo, int oszlopSzamolo_egyik, int oszlopSzamolo_masik, int lotto_number_first, int lotto_number_second, int talal)
        {

            if (sorsolasok[sorSzamolo, oszlopSzamolo_egyik] == lotto_number_first)
            {

                talal = Szamolo(sorsolasok, sorSzamolo, oszlopSzamolo_masik, lotto_number_second, talal);
            }
            else
            {
                if (sorsolasok[sorSzamolo, oszlopSzamolo_egyik] == lotto_number_second)
                {
                    talal = Szamolo(sorsolasok, sorSzamolo, oszlopSzamolo_masik, lotto_number_first, talal);
                }
            }
            return talal;
        }

        static int Szamolo(int[,] sorsolasok, int sorSzamolo, int oszlopSzamolo, int lotto_number, int talal)
        {
            talal++;
            if (sorsolasok[sorSzamolo, (oszlopSzamolo)] == lotto_number)
            {
                talal++;
            }
            return talal;
        }

        static int Find_2(int[,] sorsolasok, int sorSzamolo, int oszlopSzamolo_egyik, int oszlopSzamolo_masik, int oszlopSzamolo_harmadik, int lotto_number_first, int lotto_number_second, int lotto_number_third, int talal)
        {
            if (sorsolasok[sorSzamolo, (oszlopSzamolo_egyik)] == lotto_number_second)
            {
                talal++;
                talal = Szamolo_2(sorsolasok, sorSzamolo, oszlopSzamolo_masik, oszlopSzamolo_harmadik, lotto_number_first, lotto_number_third, talal);
            }
            else
            {
                if (sorsolasok[sorSzamolo, (oszlopSzamolo_egyik)] == lotto_number_third)
                {
                    talal++;
                    talal = Szamolo_2(sorsolasok, sorSzamolo, oszlopSzamolo_masik, oszlopSzamolo_harmadik, lotto_number_first, lotto_number_second, talal);
                }
            }
            return talal;
        }

        static int Find_3(int[,] sorsolasok, int sorSzamolo, int oszlopSzamoloharmas_egyik, int oszlopSzamoloharmas_masik, int oszlopSzamoloharmas_harmadik, int harmas_a, int harmas_b, int harmas_c, int talal3)
        {
            if (sorsolasok[sorSzamolo, (oszlopSzamoloharmas_egyik)] == harmas_a)
            {
                talal3++;
                talal3 = Szamolo_2(sorsolasok, sorSzamolo, oszlopSzamoloharmas_masik, oszlopSzamoloharmas_harmadik, harmas_b, harmas_c, talal3);
            }
            else
            {
                talal3 = Find_2(sorsolasok, sorSzamolo, oszlopSzamoloharmas_egyik, oszlopSzamoloharmas_masik, oszlopSzamoloharmas_harmadik, harmas_a, harmas_b, harmas_c, talal3);
            }
            return talal3;
        }

        static int Find_4(int[,] sorsolasok, int sorSzamolo, int oszlopSzamolonegyes_egyik, int oszlopSzamolonegyes_masik, int oszlopSzamolonegyes_harmadik, int oszlopSzamolonegyes_negyedik, int negyes_a, int negyes_b, int negyes_c, int negyes_d, int talal4)
        {
            if (sorsolasok[sorSzamolo, (oszlopSzamolonegyes_egyik)] == negyes_a)
            {
                talal4++;
                talal4 = Find_3(sorsolasok, sorSzamolo, oszlopSzamolonegyes_masik, oszlopSzamolonegyes_harmadik, oszlopSzamolonegyes_negyedik, negyes_b, negyes_c, negyes_d, talal4);

            }
            else
            {
                if (sorsolasok[sorSzamolo, (oszlopSzamolonegyes_egyik)] == negyes_b)
                {
                    talal4++;
                    talal4 = Find_3(sorsolasok, sorSzamolo, oszlopSzamolonegyes_masik, oszlopSzamolonegyes_harmadik, oszlopSzamolonegyes_negyedik, negyes_a, negyes_c, negyes_d, talal4);
                }
                else
                {
                    if (sorsolasok[sorSzamolo, (oszlopSzamolonegyes_egyik)] == negyes_c)
                    {
                        talal4++;
                        talal4 = Find_3(sorsolasok, sorSzamolo, oszlopSzamolonegyes_masik, oszlopSzamolonegyes_harmadik, oszlopSzamolonegyes_negyedik, negyes_b, negyes_a, negyes_d, talal4);

                    }
                    else
                    {
                        if (sorsolasok[sorSzamolo, (oszlopSzamolonegyes_egyik)] == negyes_d)
                        {
                            talal4++;
                            talal4 = Find_3(sorsolasok, sorSzamolo, oszlopSzamolonegyes_masik, oszlopSzamolonegyes_harmadik, oszlopSzamolonegyes_negyedik, negyes_b, negyes_c, negyes_a, talal4);
                        }
                    }
                }
            }
            return talal4;
        }

        static int Find_5(int[,] sorsolasok, int sorSzamolo, int oszlopSzamolootos_egyik, int oszlopSzamolootos_masik, int oszlopSzamolootos_harmadik, int oszlopSzamolootos_negyedik, int oszlopSzamolootos_otodik, int otos_a, int otos_b, int otos_c, int otos_d, int otos_e, int talal5)
        {

            if (sorsolasok[sorSzamolo, (oszlopSzamolootos_egyik)] == otos_a)
            {
                talal5++;
                talal5 = Find_4(sorsolasok, sorSzamolo, oszlopSzamolootos_masik, oszlopSzamolootos_harmadik, oszlopSzamolootos_negyedik, oszlopSzamolootos_otodik, otos_b, otos_c, otos_d, otos_e, talal5);

            }
            else // masodik
                 //------------------------------------------------------------------------------------------------------------------------------------------------------------
            {
                if (sorsolasok[sorSzamolo, (oszlopSzamolootos_egyik)] == otos_b)
                {
                    talal5++;
                    talal5 = Find_4(sorsolasok, sorSzamolo, oszlopSzamolootos_masik, oszlopSzamolootos_harmadik, oszlopSzamolootos_negyedik, oszlopSzamolootos_otodik, otos_a, otos_c, otos_d, otos_e, talal5);
                }
                else //harmadik	
                     //---------------------------------------------------------------------------------------------------------------------------------------
                {
                    if (sorsolasok[sorSzamolo, (oszlopSzamolootos_egyik)] == otos_c)
                    {
                        talal5++;
                        talal5 = Find_4(sorsolasok, sorSzamolo, oszlopSzamolootos_masik, oszlopSzamolootos_harmadik, oszlopSzamolootos_negyedik, oszlopSzamolootos_otodik, otos_c, otos_b, otos_d, otos_e, talal5);
                    }
                    else //negyedik
                         //-----------------------------------------------------------------------------------------------------------------------------------------------------
                    {
                        if (sorsolasok[sorSzamolo, (oszlopSzamolootos_egyik)] == otos_d)
                        {
                            talal5++;
                            talal5 = Find_4(sorsolasok, sorSzamolo, oszlopSzamolootos_masik, oszlopSzamolootos_harmadik, oszlopSzamolootos_negyedik, oszlopSzamolootos_otodik, otos_a, otos_b, otos_c, otos_e, talal5);
                        }
                        else //ötödik
                             //--------------------------------------------------------------------------------------------------------------------------------------------------------
                        {
                            if (sorsolasok[sorSzamolo, (oszlopSzamolootos_egyik)] == otos_e)
                            {
                                talal5++;
                                talal5 = Find_4(sorsolasok, sorSzamolo, oszlopSzamolootos_masik, oszlopSzamolootos_harmadik, oszlopSzamolootos_negyedik, oszlopSzamolootos_otodik, otos_a, otos_b, otos_c, otos_d, talal5);
                            }
                        }
                    }
                }
            }
            return talal5;
        }

        static int Find_6(int[,] sorsolasok, int sorSzamolo, int oszlopSzamolohatos_egyik, int oszlopSzamolohatos_masik, int oszlopSzamolohatos_harmadik, int oszlopSzamolohatos_negyedik, int oszlopSzamolohatos_otodik, int oszlopSzamolohatos_hatodik, int hatos_a, int hatos_b, int hatos_c, int hatos_d, int hatos_e, int hatos_f, int talal6)
        {

            if (sorsolasok[sorSzamolo, (oszlopSzamolohatos_egyik)] == hatos_a)
            {
                talal6++;
                talal6 = Find_5(sorsolasok, sorSzamolo, oszlopSzamolohatos_masik, oszlopSzamolohatos_harmadik, oszlopSzamolohatos_negyedik, oszlopSzamolohatos_otodik, oszlopSzamolohatos_hatodik, hatos_b, hatos_c, hatos_d, hatos_e, hatos_f, talal6);

            }
            else // masodik
                 //------------------------------------------------------------------------------------------------------------------------------------------------------------
            {
                if (sorsolasok[sorSzamolo, (oszlopSzamolohatos_egyik)] == hatos_b)
                {
                    talal6++;
                    talal6 = Find_5(sorsolasok, sorSzamolo, oszlopSzamolohatos_masik, oszlopSzamolohatos_harmadik, oszlopSzamolohatos_negyedik, oszlopSzamolohatos_otodik, oszlopSzamolohatos_hatodik, hatos_a, hatos_c, hatos_d, hatos_e, hatos_f, talal6);
                }
                else //harmadik	
                     //---------------------------------------------------------------------------------------------------------------------------------------
                {
                    if (sorsolasok[sorSzamolo, (oszlopSzamolohatos_egyik)] == hatos_c)
                    {
                        talal6++;
                        talal6 = Find_5(sorsolasok, sorSzamolo, oszlopSzamolohatos_masik, oszlopSzamolohatos_harmadik, oszlopSzamolohatos_negyedik, oszlopSzamolohatos_otodik, oszlopSzamolohatos_hatodik, hatos_c, hatos_b, hatos_d, hatos_e, hatos_f, talal6);
                    }
                    else //negyedik
                         //-----------------------------------------------------------------------------------------------------------------------------------------------------
                    {
                        if (sorsolasok[sorSzamolo, (oszlopSzamolohatos_egyik)] == hatos_d)
                        {
                            talal6++;
                            talal6 = Find_5(sorsolasok, sorSzamolo, oszlopSzamolohatos_masik, oszlopSzamolohatos_harmadik, oszlopSzamolohatos_negyedik, oszlopSzamolohatos_otodik, oszlopSzamolohatos_hatodik, hatos_a, hatos_b, hatos_c, hatos_e, hatos_f, talal6);
                        }
                        else //ötödik
                             //--------------------------------------------------------------------------------------------------------------------------------------------------------
                        {
                            if (sorsolasok[sorSzamolo, (oszlopSzamolohatos_egyik)] == hatos_e)
                            {
                                talal6++;
                                talal6 = Find_5(sorsolasok, sorSzamolo, oszlopSzamolohatos_masik, oszlopSzamolohatos_harmadik, oszlopSzamolohatos_negyedik, oszlopSzamolohatos_otodik, oszlopSzamolohatos_hatodik, hatos_a, hatos_b, hatos_c, hatos_d, hatos_f, talal6);
                            }
                            else //hatodik
                                 //--------------------------------------------------------------------------------------------------------------------------------------------------------
                            {
                                if (sorsolasok[sorSzamolo, (oszlopSzamolohatos_egyik)] == hatos_f)
                                {
                                    talal6++;
                                    talal6 = Find_5(sorsolasok, sorSzamolo, oszlopSzamolohatos_masik, oszlopSzamolohatos_harmadik, oszlopSzamolohatos_negyedik, oszlopSzamolohatos_otodik, oszlopSzamolohatos_hatodik, hatos_a, hatos_b, hatos_c, hatos_d, hatos_e, talal6);
                                }
                            }

                        }
                    }
                }
            }
            return talal6;
        }

        static void Main(string[] args)
        {
            int sorok = 0;
            //int minimax = 0;
            Console.WriteLine("Az adatok beolvasásához nyomj le egy billentyűt!");
            Console.ReadKey();
            StreamReader f = new StreamReader("skandi.csv");
            int[] skandiszamok = new int[35];
            int[] skandiszamokgepi = new int[35];
            int[] skandiszamokkezi = new int[35];
            int[] skandiszamok_nagyobb = new int[35];
            int[] skandiszamokgepi_nagyobb = new int[35];
            int[] skandiszamokkezi_nagyobb = new int[35];

            Console.WriteLine("A skandi.csv beolvasása elkezdődött....");
            while (!f.EndOfStream)
            {
                string[] adatok_skandi = f.ReadLine().Split(';');
                sorok = sorok + 1;
                for (int i = 11; i <= 24; i++)
                {
                    skandiszamok[Convert.ToInt32(adatok_skandi[i]) - 1]++; // skandiszamok nevű tömb, adatok_skandi[i]. elemét növelem 1-gyel, azaz megszámolom a nyerőszámok előfordulását
                    //Console.Write(((i == 11) ? "|| " : "") + adatok_otos[i] + ((i == 15) ? " ||" : " | ")); //az adott sort kiíratom
                }
                for (int i = 11; i <= 17; i++)
                {
                    skandiszamokgepi[Convert.ToInt32(adatok_skandi[i]) - 1]++; // skandiszamok nevű tömb, adatok_skandi[i]. elemét növelem 1-gyel, azaz megszámolom a nyerőszámok előfordulását
                    //Console.Write(((i == 11) ? "|| " : "") + adatok_otos[i] + ((i == 15) ? " ||" : " | ")); //az adott sort kiíratom
                }
                for (int i = 18; i <= 24; i++)
                {
                    skandiszamokkezi[Convert.ToInt32(adatok_skandi[i]) - 1]++; // skandiszamok nevű tömb, adatok_skandi[i]. elemét növelem 1-gyel, azaz megszámolom a nyerőszámok előfordulását
                    //Console.Write(((i == 11) ? "|| " : "") + adatok_otos[i] + ((i == 15) ? " ||" : " | ")); //az adott sort kiíratom
                }
            }
            f.Close();
            Console.WriteLine("A skandi.csv beolvasása folyamatban...");
            int[,] sorsolasok = new int[sorok, 14];
            int ss, so;
            ss = 0;
            StreamReader f_sorsolas = new StreamReader("skandi.csv");
            while (!f_sorsolas.EndOfStream)
            {
                string[] adatok_sorsolas = f_sorsolas.ReadLine().Split(';');
                so = 0;
                for (int i_feltolt = 11; i_feltolt <= 24; i_feltolt++)
                {
                    sorsolasok[ss, so] = Convert.ToInt32(adatok_sorsolas[i_feltolt]);
                    so++;
                }
                ss++;
            }
            f_sorsolas.Close();
            Console.WriteLine("A skandi.csv beolvasása elkészült...");
            Console.WriteLine("A nyerőszámokat kimásolom ....");
            string filenev = "skandi_lotto_szam_sorolasok_" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";
            Console.WriteLine("A " + filenev + " létrehozása....");
            StreamWriter f2_sorsolas = new StreamWriter(filenev, false);
            f2_sorsolas.WriteLine("Az 7/35 lottó számai (" + sorok + " sorsolás adatai alapján):");
            f2_sorsolas.WriteLine("gépi számok:");
            for (int sorkiir = 0; sorkiir < sorok; sorkiir++)
            {
                for (int oszlopkiir = 0; oszlopkiir < 7; oszlopkiir++)
                {
                    f2_sorsolas.Write(sorsolasok[sorkiir, oszlopkiir] + ";");
                }
                f2_sorsolas.WriteLine();
                f2_sorsolas.Flush();
            }
            f2_sorsolas.WriteLine();
            f2_sorsolas.WriteLine("kézi számok:");
            for (int sorkiir = 0; sorkiir < sorok; sorkiir++)
            {
                for (int oszlopkiir = 7; oszlopkiir < 14; oszlopkiir++)
                {
                    f2_sorsolas.Write(sorsolasok[sorkiir, oszlopkiir] + ";");
                }
                f2_sorsolas.WriteLine();
                f2_sorsolas.Flush();
            }
            f2_sorsolas.Close();
            Console.WriteLine("Az eddig kihúzott lottószámokat a " + filenev + "-ben találod.");
            //Console.WriteLine("A folytatáshoz nyomj le egy billentyűt!");
            //Console.ReadKey();
            Console.WriteLine("Megszámolom, hogy az egyes lottószámokat eddig mennyiszer húzták ki....");
            for (int kk = 0; kk < 35; kk++)
            {
                skandiszamok_nagyobb[kk] = skandiszamok[kk];
            }
            for (int kk = 0; kk < 35; kk++)
            {
                skandiszamokgepi_nagyobb[kk] = skandiszamokgepi[kk];
            }
            for (int kk = 0; kk < 35; kk++)
            {
                skandiszamokkezi_nagyobb[kk] = skandiszamokkezi[kk];
            }
            filenev = "skandi_lotto_szam_gyakorisag_" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";
            Console.WriteLine("A " + filenev + " létrehozása....");
            StreamWriter f2skandi = new StreamWriter(filenev, false);
            Console.WriteLine();
            f2skandi.WriteLine();
            f2skandi.WriteLine("Az 7/35 (skandináv) lottó (GÉPI+KÉZI) számai előforulás szerint rendezve, csökkenő sorrenben (" + sorok + " sorsolás adatai alapján):");
            f2skandi.WriteLine();
            int[] maxi_szamok = new int[35];
            int[] maxi_szamok_db = new int[35];
            for (int i = 0; i < 35; i++)
            {
                int maxi_index = 0; //maximum kiválasztáshoz, ez jelöli,hogy a tömbben, mi az indexe a leggyakoribb számnak
                for (int j = 0; j < 35; j++)
                {
                    if (skandiszamok_nagyobb[maxi_index] < skandiszamok_nagyobb[j])
                    {
                        maxi_index = j;
                    }
                }
                maxi_szamok[i] = maxi_index + 1;
                maxi_szamok_db[i] = skandiszamok_nagyobb[maxi_index];
                f2skandi.WriteLine("[ " + (i + 1) + ". szám: " + maxi_szamok[i] + " (" + maxi_szamok_db[i] + " előfordulás) ] " /*+ minimax*/);
                f2skandi.Flush();
                skandiszamok_nagyobb[maxi_index] = 0;
            }
            Console.WriteLine("A 7/35 (skandináv) lottó GÉPI+KÉZI számai előforulás szerint rendezve, csökkenő sorrendben.");
            Console.WriteLine(" A listát a " + filenev + "-ben találod.");
            f2skandi.WriteLine();
            f2skandi.WriteLine("A 7/35 (skandináv) lottó GÉPI számai előforulás szerint rendezve, csökkenő sorrenben (" + sorok + " sorsolás adatai alapján):");
            f2skandi.WriteLine();
            int[] maxi_szamokgepi = new int[35];
            int[] maxi_szamok_dbgepi = new int[35];
            for (int i = 0; i < 35; i++)
            {
                int maxi_index = 0; //maximum kiválasztáshoz, ez jelöli,hogy a tömbben, mi az indexe a leggyakoribb számnak
                for (int j = 0; j < 35; j++)
                {
                    if (skandiszamokgepi_nagyobb[maxi_index] < skandiszamokgepi_nagyobb[j])
                    {
                        maxi_index = j;
                    }
                }
                maxi_szamok[i] = maxi_index + 1;
                maxi_szamok_db[i] = skandiszamokgepi_nagyobb[maxi_index];
                f2skandi.WriteLine("[ " + (i + 1) + ". szám: " + maxi_szamok[i] + " (" + maxi_szamok_db[i] + " előfordulás) ] " /*+ minimax*/);
                f2skandi.Flush();
                skandiszamokgepi_nagyobb[maxi_index] = 0;
            }
            Console.WriteLine("A 7/35 (skandináv) lottó GÉPI számai előforulás szerint rendezve, csökkenő sorrendben.");
            Console.WriteLine(" A listát a " + filenev + "-ben találod.");
            f2skandi.WriteLine();
            f2skandi.WriteLine("A 7/35 (skandináv) lottó KÉZI számai előforulás szerint rendezve, csökkenő sorrenben (" + sorok + " sorsolás adatai alapján):");
            f2skandi.WriteLine();
            int[] maxi_szamokkezi = new int[35];
            int[] maxi_szamok_dbkezi = new int[35];
            for (int i = 0; i < 35; i++)
            {
                int maxi_index = 0; //maximum kiválasztáshoz, ez jelöli,hogy a tömbben, mi az indexe a leggyakoribb számnak
                for (int j = 0; j < 35; j++)
                {
                    if (skandiszamokkezi_nagyobb[maxi_index] < skandiszamokkezi_nagyobb[j])
                    {
                        maxi_index = j;
                    }
                }
                maxi_szamok[i] = maxi_index + 1;
                maxi_szamok_db[i] = skandiszamokkezi_nagyobb[maxi_index];
                f2skandi.WriteLine("[ " + (i + 1) + ". szám: " + maxi_szamok[i] + " (" + maxi_szamok_db[i] + " előfordulás) ] " /*+ minimax*/);
                f2skandi.Flush();
                skandiszamokkezi_nagyobb[maxi_index] = 0;
            }
            f2skandi.Close();
            Console.WriteLine("A 7/35 (skandináv) lottó KÉZI számai előforulás szerint rendezve, csökkenő sorrendben.");
            Console.WriteLine(" A listát a " + filenev + "-ben találod.");


            Console.WriteLine("Megszámolom, hogy az egyes lottószám párokat eddig mennyiszer húzták ki....");

 
            int talal= 0;
            int db_kettes_gepi = 0;
    
            List<string> CountedListMachine = new List<string>();
            string chk_row;
            List<string> CheckList = new List<string>();
            bool result;

            filenev = "skandi_lotto_gepi_szamok_(2)_kettesevel_" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";
            for (int RowCounterOut = 0; RowCounterOut < sorok; RowCounterOut++)
            {
                Console.WriteLine("skandi 2 gépi: " + RowCounterOut + " / " + sorok);
                for (int ColumnCounterOut_1 = 0; ColumnCounterOut_1 < 6; ColumnCounterOut_1++)
                {
                    for (int ColumnCounterOut_2 = (ColumnCounterOut_1 + 1); ColumnCounterOut_2 < 7; ColumnCounterOut_2++)
                    {
                        chk_row = sorsolasok[RowCounterOut, ColumnCounterOut_1] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_2];
                        if (!(result = CheckList.Contains(chk_row)))
                        {
                            CheckList.Add(chk_row);
                            db_kettes_gepi = 1;
                            for (int RowCounterIn = (RowCounterOut + 1); RowCounterIn < sorok; RowCounterIn++)
                            {
                                for (int ColumnCounterIn_1 = 0; ColumnCounterIn_1 < 4; ColumnCounterIn_1++)
                                {
                                    for (int ColumnCounterIn_2 = (ColumnCounterIn_1 + 1); ColumnCounterIn_2 < 5; ColumnCounterIn_2++)
                                    {
                                        talal = 0;
                                        talal = Szamolo_2(sorsolasok, RowCounterIn, ColumnCounterIn_1, ColumnCounterIn_2, sorsolasok[RowCounterOut, ColumnCounterOut_1], sorsolasok[RowCounterOut, ColumnCounterOut_2], talal);
                                        if (talal == 2)
                                        {
                                            db_kettes_gepi++;
                                        }
                                    }
                                }
                            }
                            if (db_kettes_gepi > 0)
                            {
                                CountedListMachine.Add(sorsolasok[RowCounterOut, ColumnCounterOut_1] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_2] + ";" + db_kettes_gepi);
                                db_kettes_gepi = 0;
                            }
                        }
                    }
                }
            }

            CheckList.Clear();
            Console.WriteLine();

            
            int db_kettes_kezi = 0;
            List<string> CountedListManual = new List<string>();

            string filenev2 = "skandi_lotto_kezi_szamok_(2)_kettesevel_" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";
            for (int RowCounterOut = 0; RowCounterOut < sorok; RowCounterOut++)
            {
                Console.WriteLine("skandi 2 kézi: " + RowCounterOut + " / " + sorok);
                for (int ColumnCounterOut_1 = 7; ColumnCounterOut_1 < 13; ColumnCounterOut_1++)
                {
                    for (int ColumnCounterOut_2 = (ColumnCounterOut_1 + 1); ColumnCounterOut_2 < 14; ColumnCounterOut_2++)
                    {
                        chk_row = sorsolasok[RowCounterOut, ColumnCounterOut_1] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_2];
                        if (!(result = CheckList.Contains(chk_row)))
                        {
                            CheckList.Add(chk_row);
                            db_kettes_kezi = 1;
                            for (int RowCounterIn = (RowCounterOut + 1); RowCounterIn < sorok; RowCounterIn++)
                            {
                                for (int ColumnCounterIn_1 = 0; ColumnCounterIn_1 < 4; ColumnCounterIn_1++)
                                {
                                    for (int ColumnCounterIn_2 = (ColumnCounterIn_1 + 1); ColumnCounterIn_2 < 5; ColumnCounterIn_2++)
                                    {
                                        talal = 0;
                                        talal = Szamolo_2(sorsolasok, RowCounterIn, ColumnCounterIn_1, ColumnCounterIn_2, sorsolasok[RowCounterOut, ColumnCounterOut_1], sorsolasok[RowCounterOut, ColumnCounterOut_2], talal);
                                        if (talal == 2)
                                        {
                                            db_kettes_kezi++;
                                        }
                                    }
                                }
                            }
                            if (db_kettes_kezi > 0)
                            {
                                CountedListManual.Add(sorsolasok[RowCounterOut, ColumnCounterOut_1] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_2] + ";" + db_kettes_kezi);
                                db_kettes_kezi = 0;
                            }
                        }
                    }
                }
            }
            StreamWriter f_skandi_machine_tmp = new StreamWriter("temp_machine.csv", false);
            for (int i = 0; i < CountedListMachine.Count; i++)
            {
                f_skandi_machine_tmp.WriteLine(CountedListMachine[i]);
            }
            f_skandi_machine_tmp.Close();

            StreamWriter f_skandi_manual_tmp = new StreamWriter("temp_manual.csv", false);
            for (int i = 0; i < CountedListManual.Count; i++)
            {
                f_skandi_manual_tmp.WriteLine(CountedListManual[i]);
            }
            f_skandi_manual_tmp.Close();

            StreamReader fA = new StreamReader("temp_machine.csv");
            ss = 0;
            int[,] machine2 = new int[CountedListMachine.Count, 3];
            int[,] machine2_plus = new int[CountedListMachine.Count, 3];
            while (!fA.EndOfStream)
            {
                string[] data_machine = fA.ReadLine().Split(';');
                so = 0;
                for (int i_feltolt = 0; i_feltolt < 3; i_feltolt++)
                {
                    machine2[ss, so] = Convert.ToInt32(data_machine[i_feltolt]);
                    machine2_plus[ss, so] = Convert.ToInt32(data_machine[i_feltolt]);
                    so++;
                }
                
                ss++;
            }
            fA.Close();

            StreamReader fB = new StreamReader("temp_manual.csv");
            ss = 0;
            int[,] manual2 = new int[CountedListManual.Count, 3];
            int[,] manual2_minus = new int[CountedListManual.Count, 3];
            while (!fB.EndOfStream)
            {
                string[] data_manual = fB.ReadLine().Split(';');
                so = 0;
                for (int i_feltolt = 0; i_feltolt < 3; i_feltolt++)
                {
                    manual2[ss, so] = Convert.ToInt32(data_manual[i_feltolt]);
                    manual2_minus[ss, so] = Convert.ToInt32(data_manual[i_feltolt]);
                    so++;
                }
              
                
                ss++;
            }
            fB.Close();

            for (int i = 0; i < CountedListMachine.Count; i++)
            {
                
                    for (int j= 0; j < CountedListManual.Count; j++)
                    {
                        
                            if ((machine2_plus[i,0] == manual2_minus[j,0]) &&( machine2_plus[i, 1] == manual2_minus[j, 1]))
                            {
                                machine2_plus[i, 2] = (machine2_plus[i, 2] + manual2_minus[j, 2]);
                            }
                       
                    }
                
            }

            for (int i = 0; i < CountedListMachine.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < CountedListManual.Count; k++)
                    {
                        for (int l = 0; l < 2; l++)
                        {
                            if (machine2_plus[i, j] == manual2_minus[k, l])
                            {
                                manual2_minus[k, 2] = 0;
                            }
                        }
                    }
                }
            }





            Console.WriteLine("A " + filenev + " létrehozása....");
            StreamWriter f_skandi_kettes_gepi = new StreamWriter(filenev, false);
            for (int i = 0; i < CountedListMachine.Count; i++)
            {
                f_skandi_kettes_gepi.WriteLine(machine2[i,0] + ";"+ machine2[i, 1] + "=" + machine2[i, 2]);
            }
            f_skandi_kettes_gepi.Close();
            CheckList.Clear();
            Console.WriteLine("A gépi kettes kombinációkat megszámoltam.");
            Console.WriteLine("A listát a " + filenev + "-ben találod.");
            Console.WriteLine();
            f_skandi_kettes_gepi.Close();

            Console.WriteLine("A " + filenev2 + " létrehozása....");
            StreamWriter f_skandi_kettes_kezi = new StreamWriter(filenev2, false);
            for (int i = 0; i < CountedListManual.Count; i++)
            {
                f_skandi_kettes_kezi.WriteLine(manual2[i, 0] + ";" + manual2[i, 1] + "=" + manual2[i, 2]);
            }
            f_skandi_kettes_kezi.Close();

            Console.WriteLine("A gépi kettes kombinációkat megszámoltam.");
            Console.WriteLine("A listát a " + filenev2 + "-ben találod.");
            Console.WriteLine();


            string filenev3 = "skandi_lotto_szamok_(2)_kettesevel_" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";

            Console.WriteLine("A " + filenev3 + " létrehozása....");
            StreamWriter f_skandi_kettes = new StreamWriter(filenev3, false);
            for (int i = 0; i < CountedListMachine.Count; i++)
            {
                f_skandi_kettes.WriteLine(machine2_plus[i, 0] + ";" + machine2_plus[i, 1] + "=" + machine2_plus[i, 2]);
            }

            for (int i = 0; i < CountedListManual.Count; i++)
            {
                if(manual2_minus[i, 2] >0)
                f_skandi_kettes.WriteLine(manual2_minus[i, 0] + ";" + manual2_minus[i, 1] + "=" + manual2_minus[i, 2]);
            }


            f_skandi_kettes.Close();

            CheckList.Clear();
            Console.WriteLine("A kettes (gépi + kézi) kombinációkat megszámoltam.");
            Console.WriteLine("A listát a " + filenev3 + "-ben találod.");
            Console.WriteLine();
           

            Console.WriteLine();
           







            CountedListMachine.Clear();
            CountedListManual.Clear();




            Console.WriteLine("A számolás vége, kilépéshez nyomj le egy billentyűt!");
            Console.ReadKey();
        }
    }
}

