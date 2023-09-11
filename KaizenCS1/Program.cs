namespace KaizenCS1
{
    internal class Program
    {
        private static string codePattern = "ACDEFGHKLMNPRTXYZ234579";
        private static int duplicateCodeCount = 0;
        static void Main(string[] args)
        {
            var listOfStringCodes = GenerateUniqueCodeList(1000);
            Console.WriteLine();
            Console.WriteLine("Üretilen Kod Listesi Uzunluk: " + listOfStringCodes.Count);
            Console.WriteLine("Tekrar üretilen kod sayısı: " + duplicateCodeCount);

        }


        private static List<string> GenerateUniqueCodeList(int numberOfCodes)
        {
            var listOfStringCodes = new List<string>();
            var generatedCode = string.Empty;
            for (int i = 0; listOfStringCodes.Count < numberOfCodes; i++)
            {
                generatedCode = GenerateUniqueCode();
                if (!string.IsNullOrEmpty(generatedCode))
                {
                    var isExist = CheckCode(listOfStringCodes, generatedCode);
                    if (!isExist)
                    {
                        listOfStringCodes.Add(generatedCode);
                        //Console.Write(generatedCode + "\t\t");
                    }
                    else
                    {
                        Console.WriteLine(i + "Tekrar üretilecek! aynısı üretilmişti");
                        duplicateCodeCount++;
                    }
                }
            }
            return listOfStringCodes;
        }


        private static string GenerateUniqueCode()
        {
            var code = string.Empty;
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                var randomIndex = rnd.Next(codePattern.Length);
                code += codePattern[randomIndex];
            }
            return code;
        }


        private static bool CheckCode(List<string> codeList, string code)
        {
            if (codeList.Contains(code))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}