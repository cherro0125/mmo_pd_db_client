using System.Collections.Generic;

namespace mmo_pd_db_client.Manual.DB.Constants
{
    public class SqlQuery
    {
        public static string createTablesQuery = @"                               BEGIN
                                    execute immediate 'CREATE TABLE Konta(
                                    ID NUMBER CONSTRAINT konta_PK PRIMARY KEY NOT NULL,
                                    email varchar2(64) NOT NULL,
                                    login varchar2(64) NOT NULL,
                                    password_hash varchar(255) NOT NULL,
                                    created_at DATE DEFAULT(SYSDATE) NOT NULL
                                    )';
                                    execute immediate 'CREATE TABLE Wyglad(
                                    ID NUMBER CONSTRAINT wyglad_PK PRIMARY KEY NOT NULL,
                                    sex varchar2(1) CHECK(sex IN(''k'',''m'')) NOT NULL,
                                    height NUMBER(5,2) NOT NULL,
                                    chest_width NUMBER(5,2) NOT NULL,
                                    skin_color varchar2(7) NOT NULL, -- HEX HASH COLOR 
                                    hair_color varchar2(7) NOT NULL, -- HEX HASH COLOR
                                    eye_color varchar2(7) NOT NULL, -- HEX HASH COLOR
                                    hair_type NUMBER(1) CHECK(hair_type BETWEEN 0 AND 3) NOT NULL
                                    )';
                                    execute immediate 'CREATE TABLE Mapy(
                                    ID NUMBER CONSTRAINT mapy_PK PRIMARY KEY NOT NULL,
                                    name varchar2(64) NOT NULL
                                    )';
                                    execute immediate 'CREATE TABLE Bazowe_Statystyki(
                                    ID NUMBER CONSTRAINT bazowe_statystyki_PK PRIMARY KEY NOT NULL,
                                    base_hp NUMBER NOT NULL,
                                    base_mp NUMBER NOT NULL,
                                    base_str NUMBER NOT NULL,
                                    base_ag NUMBER NOT NULL, --agility
                                    base_int NUMBER NOT NULL, -- inteligence
                                    base_stamina NUMBER NOT NULL
                                    )';
                                    --TWORZENIE TABELI TYP_UMIEJETNOSCI
                                    execute immediate 'CREATE TABLE Typy_umiejetnosci(
                                    ID NUMBER CONSTRAINT typy_um_PK PRIMARY KEY NOT NULL,
                                    type_name varchar2(255) NOT NULL
                                    )';
                                    execute immediate 'CREATE TABLE Statystyki(
                                    ID NUMBER CONSTRAINT statystyki_PK PRIMARY KEY NOT NULL,
                                    ch_level number(3) DEFAULT(1) NOT NULL,
                                    hp NUMBER NOT NULL,
                                    mana NUMBER NOT NULL,
                                    str NUMBER NOT NULL,
                                    agility NUMBER NOT NULL,
                                    inteligence NUMBER NOT NULL,
                                    stamina NUMBER NOT NULL,
                                    exp_points NUMBER NOT NULL
                                    )';
                                    execute immediate 'CREATE TABLE Klasy_postaci(
                                    ID NUMBER CONSTRAINT klasy_pos_PK PRIMARY KEY NOT NULL,
                                    class_name varchar2(255) NOT NULL,
                                    b_stat_id NUMBER  CONSTRAINT klasy_statystyki_Bazowe_FK REFERENCES Bazowe_Statystyki(ID)
                                    ON DELETE SET NULL
                                    )';
                                    execute immediate 'CREATE TABLE Rasy(
                                    ID NUMBER CONSTRAINT rasy_PK PRIMARY KEY NOT NULL,
                                    b_stat_id NUMBER NOT NULL CONSTRAINT rasy_statystyki_Bazowe_FK REFERENCES Bazowe_Statystyki(ID)
                                    ON DELETE SET NULL,
                                    model varchar2(255) DEFAULT(''VOID_MODEL'') NOT NULL
                                    )';
                                    execute immediate 'CREATE TABLE Pozycje(
                                    ID NUMBER CONSTRAINT pozycja_PK PRIMARY KEY NOT NULL,
                                    x NUMBER(10,4) NOT NULL,
                                    y NUMBER(10,4) NOT NULL,
                                    z NUMBER(10,4) NOT NULL,
                                    map_id NUMBER  CONSTRAINT pozycja_mapa_FK REFERENCES Mapy(ID)
                                    ON DELETE SET NULL
                                    )';
                                    execute immediate 'CREATE TABLE Postacie(
                                    ID NUMBER CONSTRAINT postacie_PK PRIMARY KEY NOT NULL,
                                    nickname varchar2(255) NOT NULL,
                                    stat_id NUMBER CONSTRAINT postacie_stat_FK  REFERENCES Statystyki(ID)
                                    ON DELETE SET NULL,
                                    acc_id NUMBER CONSTRAINT postacie_konto_FK REFERENCES Konta(ID)
                                    ON DELETE SET NULL,
                                    race_id NUMBER CONSTRAINT postacie_rasa_FK REFERENCES Rasy(ID) -- rasa
                                    ON DELETE SET NULL,
                                    class_id NUMBER CONSTRAINT postacie_klasa_FK REFERENCES Klasy_postaci(ID)
                                    ON DELETE SET NULL,
                                    look_id NUMBER CONSTRAINT postacie_wyglad_FK REFERENCES Wyglad(ID)
                                    ON DELETE SET NULL,
                                    pos_id NUMBER CONSTRAINT postacie_pozycja_FK REFERENCES Pozycje(ID)
                                    ON DELETE SET NULL
                                    )';
                                    execute immediate 'CREATE TABLE Umiejetnosci(
                                    ID NUMBER CONSTRAINT umiejetnosci_PK PRIMARY KEY NOT NULL,
                                    skill_type_id NUMBER CONSTRAINT umiejetnosci_typ_FK REFERENCES Typy_umiejetnosci(ID)
                                    ON DELETE SET NULL,
                                    skill_name varchar2(255) NOT NULL,
                                    base_dmg NUMBER NOT NULL
                                    )';
                                    execute immediate 'CREATE TABLE Umiejetnosci_Postac(
                                    ID NUMBER CONSTRAINT um_pos_PK PRIMARY KEY NOT NULL CHECK (ID > 0),
                                    char_id NUMBER CONSTRAINT to_pos_FK REFERENCES Postacie(ID)
                                    ON DELETE SET NULL,
                                    skill_id NUMBER CONSTRAINT to_skill_FK REFERENCES Umiejetnosci(ID)
                                    ON DELETE SET NULL
                                    )';
                                    END;";

        public static string dropTablesQuery = @"BEGIN
                                                execute immediate ' DROP TABLE Konta CASCADE CONSTRAINTS';
                                                execute immediate ' DROP TABLE Wyglad CASCADE CONSTRAINTS';
                                                execute immediate ' DROP TABLE Mapy CASCADE CONSTRAINTS';
                                                execute immediate ' DROP TABLE Bazowe_Statystyki CASCADE CONSTRAINTS';
                                                execute immediate ' DROP TABLE Typy_umiejetnosci CASCADE CONSTRAINTS';
                                                execute immediate ' DROP TABLE Statystyki CASCADE CONSTRAINTS';
                                                execute immediate ' DROP TABLE Klasy_postaci CASCADE CONSTRAINTS';
                                                execute immediate ' DROP TABLE Rasy CASCADE CONSTRAINTS';
                                                execute immediate ' DROP TABLE Pozycje CASCADE CONSTRAINTS';
                                                execute immediate ' DROP TABLE Postacie CASCADE CONSTRAINTS';
                                                execute immediate ' DROP TABLE Umiejetnosci CASCADE CONSTRAINTS';
                                                execute immediate ' DROP TABLE Umiejetnosci_Postac CASCADE CONSTRAINTS';
                                                END;";

        public static string createSequencesQuery = @"BEGIN
                                                    execute immediate ' CREATE SEQUENCE Konta_seq START WITH 1';
                                                    execute immediate ' CREATE SEQUENCE Wyglad_seq START WITH 1';
                                                    execute immediate ' CREATE SEQUENCE Mapy_seq START WITH 1';
                                                    execute immediate ' CREATE SEQUENCE Bazowe_Statystyki_seq START WITH 1';
                                                    execute immediate ' CREATE SEQUENCE Typy_umiejetnosci_seq START WITH 1';
                                                    execute immediate ' CREATE SEQUENCE Statystyki_seq START WITH 1';
                                                    execute immediate ' CREATE SEQUENCE Klasy_postaci_seq START WITH 1';
                                                    execute immediate ' CREATE SEQUENCE Rasy_seq START WITH 1';
                                                    execute immediate ' CREATE SEQUENCE Pozycje_seq START WITH 1';
                                                    execute immediate ' CREATE SEQUENCE Postacie_seq START WITH 1';
                                                    execute immediate ' CREATE SEQUENCE Umiejetnosci_seq START WITH 1';
                                                    execute immediate ' CREATE SEQUENCE Umiejetnosci_Postac_seq START WITH 1';
                                                    END;";

        public static string dropSequencesQuery = @"BEGIN
                                                    execute immediate ' DROP SEQUENCE Konta_seq ';
                                                    execute immediate ' DROP SEQUENCE Wyglad_seq ';
                                                    execute immediate ' DROP SEQUENCE Mapy_seq ';
                                                    execute immediate ' DROP SEQUENCE Bazowe_Statystyki_seq ';
                                                    execute immediate ' DROP SEQUENCE Typy_umiejetnosci_seq ';
                                                    execute immediate ' DROP SEQUENCE Statystyki_seq ';
                                                    execute immediate ' DROP SEQUENCE Klasy_postaci_seq ';
                                                    execute immediate ' DROP SEQUENCE Rasy_seq ';
                                                    execute immediate ' DROP SEQUENCE Pozycje_seq ';
                                                    execute immediate ' DROP SEQUENCE Postacie_seq ';
                                                    execute immediate ' DROP SEQUENCE Umiejetnosci_seq ';
                                                    execute immediate ' DROP SEQUENCE Umiejetnosci_Postac_seq ';
                                                    END;";

        public static List<string> insertExampleData = new List<string>(new string[]
        {
            "INSERT INTO Konta VALUES(Konta_seq.NEXTVAL,'janush@nos.pl','passat88','DWDWDWDWD3131313DDWDWDSASADADADADAD##!#!#!@@',SYSDATE)",
            "INSERT INTO Konta VALUES(Konta_seq.NEXTVAL,'janosik@pieronie.pl','pyzdrach','121313DDWDWD##!#dSASASASAS!#!@@',SYSDATE)",
            "INSERT INTO Konta VALUES(Konta_seq.NEXTVAL,'krzysztof@marynarz.pl','chcialbymbyc','121313DDWDWD##!#dSASASADAE!#!@@',SYSDATE+5)",
            "INSERT INTO Konta VALUES(Konta_seq.NEXTVAL,'krawczyk@piosenkarzem.pl','songmebabe','331313DDWDWD##!#dSAAASASAS!#!@@',SYSDATE+1)",
            "INSERT INTO Konta VALUES(Konta_seq.NEXTVAL,'maryla@rodo.eu','neverdiebeforenewyear','121313DDWDWD##!#dSASASASAS!#!@@',SYSDATE+3)",

            "INSERT INTO Wyglad VALUES(Wyglad_seq.NEXTVAL,'m',170,30,'#FF00AA','#FFBBCC','#0F00AA',1)",
            "INSERT INTO Wyglad VALUES(Wyglad_seq.NEXTVAL,'k',140,70,'#FFB0AA','#CCCCAA','#FA00AA',1)",
            "INSERT INTO Wyglad VALUES(Wyglad_seq.NEXTVAL,'m',150,90,'#FFAAAA','#CCBBAA','#FD00AA',2)",
            "INSERT INTO Wyglad VALUES(Wyglad_seq.NEXTVAL,'m',160,120,'#FFB0CC','#CCFFCC','#2F00AA',3)",
            "INSERT INTO Wyglad VALUES(Wyglad_seq.NEXTVAL,'k',190,150,'#DDB0AA','#AABBCC','#3F40AA',2)",

            "INSERT INTO Mapy VALUES(Mapy_seq.NEXTVAL,'map_2tsuded')",
            "INSERT INTO Mapy VALUES(Mapy_seq.NEXTVAL,'map_atlantide')",
            "INSERT INTO Mapy VALUES(Mapy_seq.NEXTVAL,'map_slask')",
            "INSERT INTO Mapy VALUES(Mapy_seq.NEXTVAL,'map_sosnowiec')",
            "INSERT INTO Mapy VALUES(Mapy_seq.NEXTVAL,'map_janosikfield')",

            "INSERT INTO Bazowe_statystyki VALUES(Bazowe_statystyki_seq.NEXTVAL,200,300,4,20,33,100)",
            "INSERT INTO Bazowe_statystyki VALUES(Bazowe_statystyki_seq.NEXTVAL,500,200,45,50,4,200)",
            "INSERT INTO Bazowe_statystyki VALUES(Bazowe_statystyki_seq.NEXTVAL,1000,300,24,25,4,500)",
            "INSERT INTO Bazowe_statystyki VALUES(Bazowe_statystyki_seq.NEXTVAL,2000,1000,34,30,3,600)",
            "INSERT INTO Bazowe_statystyki VALUES(Bazowe_statystyki_seq.NEXTVAL,100,1400,74,55,3,400)",


            "INSERT INTO Typy_umiejetnosci VALUES(Typy_umiejetnosci_seq.NEXTVAL,'active_fire_mage')",
            "INSERT INTO Typy_umiejetnosci VALUES(Typy_umiejetnosci_seq.NEXTVAL,'passive_warrior')",
            "INSERT INTO Typy_umiejetnosci VALUES(Typy_umiejetnosci_seq.NEXTVAL,'passive_mage')",
            "INSERT INTO Typy_umiejetnosci VALUES(Typy_umiejetnosci_seq.NEXTVAL,'passive_hunter')",
            "INSERT INTO Typy_umiejetnosci VALUES(Typy_umiejetnosci_seq.NEXTVAL,'active_speed_rouge')",


            "INSERT INTO Klasy_postaci VALUES(Klasy_postaci_seq.NEXTVAL,'mage',1)",
            "INSERT INTO Klasy_postaci VALUES(Klasy_postaci_seq.NEXTVAL,'warrior',2)",
            "INSERT INTO Klasy_postaci VALUES(Klasy_postaci_seq.NEXTVAL,'hunter',3)",
            "INSERT INTO Klasy_postaci VALUES(Klasy_postaci_seq.NEXTVAL,'rouge',4)",
            "INSERT INTO Klasy_postaci VALUES(Klasy_postaci_seq.NEXTVAL,'traitor',5)",


            "INSERT INTO Rasy VALUES(Rasy_seq.NEXTVAL,1,'human_man_model_01')",
            "INSERT INTO Rasy VALUES(Rasy_seq.NEXTVAL,2,'orc_woman_model_01')",
            "INSERT INTO Rasy VALUES(Rasy_seq.NEXTVAL,2,'orc_man_model_01')",
            "INSERT INTO Rasy VALUES(Rasy_seq.NEXTVAL,2,'elf_woman_model_01')",
            "INSERT INTO Rasy VALUES(Rasy_seq.NEXTVAL,2,'elf_man_model_01')",


            "INSERT INTO Pozycje VALUES(Pozycje_seq.NEXTVAL,10,20,302,1)",
            "INSERT INTO Pozycje VALUES(Pozycje_seq.NEXTVAL,20,5.5,372.55,2)",
            "INSERT INTO Pozycje VALUES(Pozycje_seq.NEXTVAL,50,6.5,40.65,3)",
            "INSERT INTO Pozycje VALUES(Pozycje_seq.NEXTVAL,25,7.5,40.55,4)",
            "INSERT INTO Pozycje VALUES(Pozycje_seq.NEXTVAL,22,12.5,55.55,4)",


            "INSERT INTO Statystyki VALUES(Statystyki_seq.NEXTVAL,10,100,200,10,25,33,120,3)",
            "INSERT INTO Statystyki VALUES(Statystyki_seq.NEXTVAL,20,200,400,60,26,34,112,11)",
            "INSERT INTO Statystyki VALUES(Statystyki_seq.NEXTVAL,30,300,300,50,27,33,997,2222)",
            "INSERT INTO Statystyki VALUES(Statystyki_seq.NEXTVAL,40,400,100,40,28,32,666,2224)",
            "INSERT INTO Statystyki VALUES(Statystyki_seq.NEXTVAL,200,500,50,20,30,31,69,2222)",


            "INSERT INTO Postacie VALUES(Postacie_seq.NEXTVAL,'WladcaPassata',1,1,1,1,1,1)",
            "INSERT INTO Postacie VALUES(Postacie_seq.NEXTVAL,'VernonRochePatriotaJakichMalo',2,2,2,2,2,2)",
            "INSERT INTO Postacie VALUES(Postacie_seq.NEXTVAL,'Legolas5214124PL',3,4,3,3,3,3)",
            "INSERT INTO Postacie VALUES(Postacie_seq.NEXTVAL,'Anubisos',4,5,2,4,4,4)",
            "INSERT INTO Postacie VALUES(Postacie_seq.NEXTVAL,'666Kitten666',5,3,5,4,4,4)",

            "INSERT INTO Umiejetnosci VALUES(Umiejetnosci_seq.NEXTVAL,1,'Fireball',150)",
            "INSERT INTO Umiejetnosci VALUES(Umiejetnosci_seq.NEXTVAL,2,'Iron Skin',150)",
            "INSERT INTO Umiejetnosci VALUES(Umiejetnosci_seq.NEXTVAL,3,'Inteligence of Asgard',150)",
            "INSERT INTO Umiejetnosci VALUES(Umiejetnosci_seq.NEXTVAL,4,'Born to be wild',150)",
            "INSERT INTO Umiejetnosci VALUES(Umiejetnosci_seq.NEXTVAL,5,'Run Forest! Run!',150)",


            "INSERT INTO Umiejetnosci_Postac VALUES(Umiejetnosci_Postac_seq.NEXTVAL,1,1)",
            "INSERT INTO Umiejetnosci_Postac VALUES(Umiejetnosci_Postac_seq.NEXTVAL,2,2)",
            "INSERT INTO Umiejetnosci_Postac VALUES(Umiejetnosci_Postac_seq.NEXTVAL,3,4)",
            "INSERT INTO Umiejetnosci_Postac VALUES(Umiejetnosci_Postac_seq.NEXTVAL,4,5)",
            "INSERT INTO Umiejetnosci_Postac VALUES(Umiejetnosci_Postac_seq.NEXTVAL,5,3)"
        }); 

        public static string insertNotValidData = @"BEGIN
                                                    execute immediate 'INSERT INTO Umiejetnosci_Postac VALUES(1,5,5)';
                                                    execute immediate 'INSERT INTO Umiejetnosci VALUES(NULL,NULL,NULL,NULL)';
                                                    execute immediate 'INSERT INTO Umiejetnosci_Postac VALUES(-2,5,5)';
                                                     END;";


        public static List<string> truncateTables = new List<string>(new string[] {
                                                                                    "DELETE FROM  Konta",
                                                                                    "DELETE FROM  Wyglad",
                                                                                    "DELETE FROM  Mapy",
                                                                                    "DELETE FROM  Bazowe_Statystyki",
                                                                                    "DELETE FROM  Typy_umiejetnosci",
                                                                                    "DELETE FROM  Statystyki",
                                                                                    "DELETE FROM  Klasy_postaci",
                                                                                    "DELETE FROM  Rasy",
                                                                                    "DELETE FROM  Pozycje",
                                                                                    "DELETE FROM  Postacie",
                                                                                    "DELETE FROM  Umiejetnosci",
                                                                                    "DELETE FROM  Umiejetnosci_Postac"

        });

        public static List<string> createViews = new List<string>(new string[]
        {
            @"CREATE OR REPLACE VIEW Gracze_na_mapach AS
                                            SELECT m.name,COUNT(p.ID) as ilosc_graczy
                                            FROM Mapy m
                                            INNER JOIN Pozycje pos
                                            ON m.ID = pos.map_id
                                            INNER JOIN Postacie p
                                            ON p.pos_id = pos.ID
                                            GROUP BY m.name",
            @"CREATE OR REPLACE VIEW Postacie_level_avg AS
            SELECT k.email,k.login,p.nickname,s.ch_level FROM Postacie p
            INNER JOIN Konta k
            ON k.ID = p.acc_ID
            INNER JOIN Statystyki s
            ON p.stat_id = s.ID
            WHERE s.CH_LEVEL > (SELECT AVG(CH_LEVEL) FROM Statystyki)",
                        @"CREATE OR REPLACE VIEW konta_rejestracja_dzien AS
            SELECT EXTRACT(DAY FROM k.created_at) as Dzien, COUNT(k.ID) as ilosc_kont 
            FROM Konta k
            GROUP BY EXTRACT(DAY FROM k.created_at)
            ORDER BY EXTRACT(DAY FROM k.created_at)",
                        @"CREATE OR REPLACE VIEW postacie_wysokosc_mapa AS
            SELECT p.NICKNAME,m.name as nazwa_mapy, pos.z as wysokosc_na_mapie FROM Pozycje pos
            INNER JOIN Postacie p
            ON p.pos_id = pos.ID
            INNER JOIN Mapy m
            ON pos.map_id = m.ID
            WHERE pos.z > (SELECT AVG(z) FROM Pozycje )",
                        @"CREATE OR REPLACE VIEW wysokosci_widok AS
             SELECT SUM(wyg.HEIGHT) as suma_wysokosci_pewnych_ras, MAX(wyg.HEIGHT) as najzwyzszy_z_pewnych_ras
             FROM Wyglad wyg
             WHERE EXISTS(
             SELECT * FROM Postacie p
             WHERE p.look_id = wyg.ID
             AND RACE_ID BETWEEN 1 AND 3
             )"
        }); 

        public static List<string> dropTriggers  = new List<string>(new string[]
        {
            "DROP TRIGGER klasy_postaci_trigg",
            "DROP TRIGGER konta_trigg",
            "DROP TRIGGER mapy_trigg",
            "DROP TRIGGER postacie_trigg",
            "DROP TRIGGER pozycje_trigg",
            "DROP TRIGGER rasy_trigg",
            "DROP TRIGGER statystyki_trigg",
            "DROP TRIGGER typy_umiejetnosci_trigg",
            "DROP TRIGGER umiejetnosci_trigg",
            "DROP TRIGGER umiejetnosci_postac_trigg",
            "DROP TRIGGER wyglad_trigg",
            "DROP TRIGGER bazowe_statystyki_trigg"
        });
    }
}