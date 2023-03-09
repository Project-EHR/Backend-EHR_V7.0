namespace EasyHouseRent
{
    public class Prohibitions
    {
        static string[] palabras = {
            "Idiota","Pornografia","Hp","Porno","Estupido","Gonorrea","XXX","Sida","Hijueputa","","","","","","","","","","","",
            "","","","","","","","","","","","","","","","","","","","",
            "","","","","","","","","","","","","","","","","","","","",
            "","","","","","","","","","","","","","","","","","","","",
        };
        public static string validateName(string word)
        {
            foreach (string c in palabras)
            {
                if (c == word)
                {
                    word = "Invalid";
                }
            }

            return word;
        }
    }
}
