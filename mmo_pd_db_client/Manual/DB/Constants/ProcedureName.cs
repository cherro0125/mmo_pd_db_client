namespace mmo_pd_db_client.Manual.DB.Constants
{
    public class ProcedureName
    {
        #region mmo_package

        public static string prefix = "mmo.";
        public static string find_race = "znajdz_rase";
        public static string find_class = "znajdz_klase";
        public static string check_is_account_exists = "sprawdz_czy_konto_istnieje";
        public static string generate_position = "generuj_pozycje";
        public static string generate_look = "generuj_wyglad";
        public static string add_statistics = "dodaj_statystyki";
        public static string add_character = "dodaj_postac";
        #endregion

        #region mmo_test_package

        public static string test_prefix = "mmo_test.";
        public static string test_find_race = "znajdz_rase";
        public static string test_find_class = "znajdz_klase";
        public static string test_check_is_account_exists = "sprawdz_czy_konto_istnieje";
        public static string test_generate_position = "generuj_pozycje";
        public static string test_generate_look = "generuj_wyglad";
        public static string test_add_statistics = "dodaj_statystyki";
        public static string test_add_character = "dodaj_postac";
        #endregion

        public static string BuildProcedureName(PackageType type, string procedureName)
        {
            if (type == PackageType.NORMAL)
                return prefix + procedureName;
            else
            {
                return test_prefix + procedureName;
            }
        }
    }
}