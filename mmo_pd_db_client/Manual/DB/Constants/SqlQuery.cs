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
                                    execute immediate 'COMMIT';
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
                                                execute immediate 'COMMIT';
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
                                                    execute immediate 'COMMIT';
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
                                                    execute immediate 'COMMIT';                                                     
                                                    END;";

        public static LinkedList<string> insertExampleData = new LinkedList<string>(new string[]
        {
            "INSERT INTO Konta VALUES(1,'janush@nos.pl','passat88','DWDWDWDWD3131313DDWDWDSASADADADADAD##!#!#!@@',SYSDATE)",
            "INSERT INTO Konta VALUES(2,'janosik@pieronie.pl','pyzdrach','121313DDWDWD##!#dSASASASAS!#!@@',SYSDATE)",
            "INSERT INTO Konta VALUES(3,'krzysztof@marynarz.pl','chcialbymbyc','121313DDWDWD##!#dSASASADAE!#!@@',SYSDATE+5)",
            "INSERT INTO Konta VALUES(4,'krawczyk@piosenkarzem.pl','songmebabe','331313DDWDWD##!#dSAAASASAS!#!@@',SYSDATE+1)",
            "INSERT INTO Konta VALUES(5,'maryla@rodo.eu','neverdiebeforenewyear','121313DDWDWD##!#dSASASASAS!#!@@',SYSDATE+3)",
            "COMMIT",

            "INSERT INTO Wyglad VALUES(1,'m',170,30,'#FF00AA','#FFBBCC','#0F00AA',1)",
            "INSERT INTO Wyglad VALUES(2,'k',140,70,'#FFB0AA','#CCCCAA','#FA00AA',1)",
            "INSERT INTO Wyglad VALUES(3,'m',150,90,'#FFAAAA','#CCBBAA','#FD00AA',2)",
            "INSERT INTO Wyglad VALUES(4,'m',160,120,'#FFB0CC','#CCFFCC','#2F00AA',3)",
            "INSERT INTO Wyglad VALUES(5,'k',190,150,'#DDB0AA','#AABBCC','#3F40AA',2)",
            "COMMIT",

            "INSERT INTO Mapy VALUES(1,'map_2tsuded')",
            "INSERT INTO Mapy VALUES(2,'map_atlantide')",
            "INSERT INTO Mapy VALUES(3,'map_slask')",
            "INSERT INTO Mapy VALUES(4,'map_sosnowiec')",
            "INSERT INTO Mapy VALUES(5,'map_janosikfield')",
            "COMMIT",

            "INSERT INTO Bazowe_statystyki VALUES(1,200,300,4,20,33,100)",
            "INSERT INTO Bazowe_statystyki VALUES(2,500,200,45,50,4,200)",
            "INSERT INTO Bazowe_statystyki VALUES(3,1000,300,24,25,4,500)",
            "INSERT INTO Bazowe_statystyki VALUES(4,2000,1000,34,30,3,600)",
            "INSERT INTO Bazowe_statystyki VALUES(5,100,1400,74,55,3,400)",
            "COMMIT",


            "INSERT INTO Typy_umiejetnosci VALUES(1,'active_fire_mage')",
            "INSERT INTO Typy_umiejetnosci VALUES(2,'passive_warrior')",
            "INSERT INTO Typy_umiejetnosci VALUES(3,'passive_mage')",
            "INSERT INTO Typy_umiejetnosci VALUES(4,'passive_hunter')",
            "INSERT INTO Typy_umiejetnosci VALUES(5,'active_speed_rouge')",
            "COMMIT",


            "INSERT INTO Klasy_postaci VALUES(1,'mage',1)",
            "INSERT INTO Klasy_postaci VALUES(2,'warrior',2)",
            "INSERT INTO Klasy_postaci VALUES(3,'hunter',3)",
            "INSERT INTO Klasy_postaci VALUES(4,'rouge',4)",
            "INSERT INTO Klasy_postaci VALUES(5,'traitor',5)",
            "COMMIT",


            "INSERT INTO Rasy VALUES(1,1,'human_man_model_01')",
            "INSERT INTO Rasy VALUES(2,2,'orc_woman_model_01')",
            "INSERT INTO Rasy VALUES(3,2,'orc_man_model_01')",
            "INSERT INTO Rasy VALUES(4,2,'elf_woman_model_01')",
            "INSERT INTO Rasy VALUES(5,2,'elf_man_model_01')",
            "COMMIT",


            "INSERT INTO Pozycje VALUES(1,10,20,302,1)",
            "INSERT INTO Pozycje VALUES(2,20,5.5,372.55,2)",
            "INSERT INTO Pozycje VALUES(3,50,6.5,40.65,3)",
            "INSERT INTO Pozycje VALUES(4,25,7.5,40.55,4)",
            "INSERT INTO Pozycje VALUES(5,22,12.5,55.55,4)",
            "COMMIT",


            "INSERT INTO Statystyki VALUES(1,10,100,200,10,25,33,120,3)",
            "INSERT INTO Statystyki VALUES(2,20,200,400,60,26,34,112,11)",
            "INSERT INTO Statystyki VALUES(3,30,300,300,50,27,33,997,2222)",
            "INSERT INTO Statystyki VALUES(4,40,400,100,40,28,32,666,2224)",
            "INSERT INTO Statystyki VALUES(5,200,500,50,20,30,31,69,2222)",
            "COMMIT",


            "INSERT INTO Postacie VALUES(1,'WladcaPassata',1,1,1,1,1,1)",
            "INSERT INTO Postacie VALUES(2,'VernonRochePatriotaJakichMalo',2,2,2,2,2,2)",
            "INSERT INTO Postacie VALUES(3,'Legolas5214124PL',3,4,3,3,3,3)",
            "INSERT INTO Postacie VALUES(4,'Anubisos',4,5,2,4,4,4)",
            "INSERT INTO Postacie VALUES(5,'666Kitten666',5,3,5,4,4,4)",
            "COMMIT",

            "INSERT INTO Umiejetnosci VALUES(1,1,'Fireball',150)",
            "INSERT INTO Umiejetnosci VALUES(2,2,'Iron Skin',150)",
            "INSERT INTO Umiejetnosci VALUES(3,3,'Inteligence of Asgard',150)",
            "INSERT INTO Umiejetnosci VALUES(4,4,'Born to be wild',150)",
            "INSERT INTO Umiejetnosci VALUES(5,5,'Run Forest! Run!',150)",
            "COMMIT",

            "INSERT INTO Umiejetnosci_Postac VALUES(1,1,1)",
            "INSERT INTO Umiejetnosci_Postac VALUES(2,2,2)",
            "INSERT INTO Umiejetnosci_Postac VALUES(3,3,4)",
            "INSERT INTO Umiejetnosci_Postac VALUES(4,4,5)",
            "INSERT INTO Umiejetnosci_Postac VALUES(5,5,3)",
            "COMMIT"
        });

        public static string insertNotValidData = @"BEGIN
                                                    execute immediate 'INSERT INTO Umiejetnosci_Postac VALUES(1,5,5)';
                                                    execute immediate 'INSERT INTO Umiejetnosci VALUES(NULL,NULL,NULL,NULL)';
                                                    execute immediate 'INSERT INTO Umiejetnosci_Postac VALUES(-2,5,5)';
                                                    execute immediate 'COMMIT';
                                                     END;";


        public static LinkedList<string> truncateTables = new LinkedList<string>(new string[] {
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
                                                                                    "DELETE FROM  Umiejetnosci_Postac",
                                                                                    "COMMIT"

        });

        public static LinkedList<string> createViews = new LinkedList<string>(new string[]
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
             )",
            "COMMIT"
        });

        public static LinkedList<string> dropTriggers = new LinkedList<string>(new string[]
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
            "DROP TRIGGER bazowe_statystyki_trigg",
            "COMMIT"
        });

        public static LinkedList<string> createTriggers = new LinkedList<string>(new string[]
        {
            @"CREATE OR REPLACE TRIGGER klasy_postaci_trigg 
            BEFORE INSERT ON KLASY_POSTACI 
            FOR EACH ROW
            BEGIN
              SELECT KLASY_POSTACI_SEQ.NEXTVAL
              INTO   :new.ID
              FROM   dual;
            END;",
            @"CREATE OR REPLACE TRIGGER konta_trigg 
                BEFORE INSERT ON KONTA 
                FOR EACH ROW
                BEGIN
                  SELECT KONTA_SEQ.NEXTVAL
                  INTO   :new.ID
                  FROM   dual;
                END;",
            @"CREATE OR REPLACE TRIGGER mapy_trigg 
                BEFORE INSERT ON MAPY 
                FOR EACH ROW
                BEGIN
                  SELECT MAPY_SEQ.NEXTVAL
                  INTO   :new.ID
                  FROM   dual;
                END;",
            @"CREATE OR REPLACE TRIGGER postacie_trigg 
                BEFORE INSERT ON POSTACIE 
                FOR EACH ROW
                BEGIN
                  SELECT POSTACIE_SEQ.NEXTVAL
                  INTO   :new.ID
                  FROM   dual;
                END;",
            @"CREATE OR REPLACE TRIGGER pozycje_trigg 
                BEFORE INSERT ON POZYCJE 
                FOR EACH ROW
                BEGIN
                  SELECT POZYCJE_SEQ.NEXTVAL
                  INTO   :new.ID
                  FROM   dual;
                END;",
            @"CREATE OR REPLACE TRIGGER rasy_trigg 
                BEFORE INSERT ON RASY 
                FOR EACH ROW
                BEGIN
                  SELECT RASY_SEQ.NEXTVAL
                  INTO   :new.ID
                  FROM   dual;
                END;",
            @"CREATE OR REPLACE TRIGGER statystyki_trigg 
                BEFORE INSERT ON STATYSTYKI 
                FOR EACH ROW
                BEGIN
                  SELECT STATYSTYKI_SEQ.NEXTVAL
                  INTO   :new.ID
                  FROM   dual;
                END;",
            @"CREATE OR REPLACE TRIGGER typy_umiejetnosci_trigg 
                BEFORE INSERT ON TYPY_UMIEJETNOSCI 
                FOR EACH ROW
                BEGIN
                  SELECT TYPY_UMIEJETNOSCI_SEQ.NEXTVAL
                  INTO   :new.ID
                  FROM   dual;
                END;",
            @"CREATE OR REPLACE TRIGGER umiejetnosci_trigg 
                BEFORE INSERT ON UMIEJETNOSCI 
                FOR EACH ROW
                BEGIN
                  SELECT UMIEJETNOSCI_SEQ.NEXTVAL
                  INTO   :new.ID
                  FROM   dual;
                END;",
            @"CREATE OR REPLACE TRIGGER umiejetnosci_postac_trigg 
                BEFORE INSERT ON UMIEJETNOSCI_POSTAC 
                FOR EACH ROW
                BEGIN
                  SELECT UMIEJETNOSCI_POSTAC_SEQ.NEXTVAL
                  INTO   :new.ID
                  FROM   dual;
                END;",
            @"CREATE OR REPLACE TRIGGER wyglad_trigg 
                BEFORE INSERT ON WYGLAD 
                FOR EACH ROW
                BEGIN
                  SELECT WYGLAD_SEQ.NEXTVAL
                  INTO   :new.ID
                  FROM   dual;
                END;",
            @"CREATE OR REPLACE TRIGGER bazowe_statystyki_trigg 
                BEFORE INSERT ON BAZOWE_STATYSTYKI
                FOR EACH ROW
                BEGIN
                    SELECT Bazowe_Statystyki_seq.NEXTVAL
                    INTO :new.ID
                    FROM dual;
                END;"

        });

        public static LinkedList<string> dropPackages = new LinkedList<string>(new string[]
        {
            "DROP PACKAGE mmo",
            "DROP PACKAGE mmo_test",
            "COMMIT"
        });

        public static LinkedList<string> createPackagesHeaders = new LinkedList<string>(new string[]
        {
            @"CREATE OR REPLACE PACKAGE mmo AS 
                                                       
                                                        FUNCTION znajdz_rase(rasa varchar2,plec WYGLAD.SEX%TYPE) RETURN NUMBER;
                                                        FUNCTION znajdz_klase(klasa varchar2) RETURN NUMBER;
                                                        FUNCTION sprawdz_czy_konto_istnieje(acc_id KONTA.ID%TYPE) RETURN NUMBER;
                                                        FUNCTION generuj_pozycje RETURN NUMBER;
                                                        FUNCTION generuj_wyglad(plec WYGLAD.SEX%TYPE) RETURN NUMBER;
                                                        FUNCTION dodaj_statystyki(klasa number, rasa number) RETURN NUMBER;
                                                        FUNCTION dodaj_postac(acc_id KONTA.ID%TYPE, nick POSTACIE.NICKNAME%TYPE, rasa varchar2, klasa varchar2, plec WYGLAD.SEX%TYPE ) RETURN NUMBER; 
                                                    END mmo;",
            @"CREATE OR REPLACE PACKAGE mmo_test AS
    PROCEDURE znajdz_rase(good_data boolean);
    PROCEDURE znajdz_klase(good_data boolean);
    PROCEDURE sprawdz_czy_konto_istnieje(good_data boolean);
    PROCEDURE generuj_pozycje;
    PROCEDURE generuj_wyglad(good_data boolean);
    PROCEDURE dodaj_statystyki(good_data boolean);
    PROCEDURE dodaj_postac;
END mmo_test;"
        });

        public static LinkedList<string> createPackagesBody = new LinkedList<string>(new string[]
        {
            @"CREATE OR REPLACE PACKAGE BODY mmo AS  
    FUNCTION znajdz_rase(rasa varchar2,plec WYGLAD.SEX%TYPE) RETURN NUMBER
    IS
    sex_not_found EXCEPTION;
    race_not_found EXCEPTION;
    BEGIN
        IF rasa = 'human' THEN
            IF plec = 'm' THEN
                RETURN 1;
            ELSIF plec = 'k' THEN
                RETURN 1;
            ELSE
                RAISE sex_not_found;
            END IF;
        ELSIF rasa = 'orc' THEN
            IF plec = 'm' THEN
                RETURN 3;
            ELSIF plec = 'k' THEN
                RETURN 2;
            ELSE
                RAISE sex_not_found;
            END IF;
        ELSIF rasa = 'elf' THEN
            IF plec = 'm' THEN
                RETURN 5;
            ELSIF plec = 'k' THEN
                RETURN 4;
            ELSE
                RAISE sex_not_found;
            END IF;
        ELSE
            RAISE race_not_found;
        END IF;
        EXCEPTION
        WHEN sex_not_found THEN
            DBMS_OUTPUT.ENABLE;
            DBMS_OUTPUT.PUT_LINE('Sex not found');
            RETURN -1;
        WHEN race_not_found THEN
            DBMS_OUTPUT.ENABLE;
            DBMS_OUTPUT.PUT_LINE('Race not found');
            RETURN -1;     
        WHEN others THEN
            DBMS_OUTPUT.ENABLE;
            DBMS_OUTPUT.PUT_LINE('Other exception');
            RETURN -1;
    END znajdz_rase;
    
    FUNCTION znajdz_klase(klasa varchar2) RETURN NUMBER
    IS
        CURSOR klasa_cursor IS SELECT ID,CLASS_NAME, B_STAT_ID FROM KLASY_POSTACI WHERE CLASS_NAME = klasa;
        found boolean := false;
        klasa_id KLASY_POSTACI.ID%TYPE;
        class_not_found EXCEPTION;
    BEGIN
        FOR rec IN klasa_cursor
        LOOP
            found := true;
            klasa_id := rec.ID;
        END LOOP;
        IF found = true THEN
            RETURN klasa_id;
        ELSE
            RAISE class_not_found;
        END IF;
        EXCEPTION
            WHEN class_not_found THEN
                DBMS_OUTPUT.ENABLE;
                DBMS_OUTPUT.PUT_LINE('Class not found');
                RETURN -1;
            WHEN others THEN
                DBMS_OUTPUT.ENABLE;
                DBMS_OUTPUT.PUT_LINE('Other exception');
                RETURN -1;
    END znajdz_klase;
    
    FUNCTION sprawdz_czy_konto_istnieje(acc_id KONTA.ID%TYPE) RETURN NUMBER
    IS
    CURSOR konto_cursor IS SELECT ID FROM KONTA WHERE ID = acc_id;
    found boolean := false;
    account_not_found EXCEPTION;
    BEGIN
        FOR rec IN konto_cursor
        LOOP
            found := true;
        END LOOP;
        IF found = true THEN
            RETURN 1;
        ELSE
            RAISE account_not_found;
        END IF;
        EXCEPTION
            WHEN account_not_found THEN
                DBMS_OUTPUT.ENABLE;
                DBMS_OUTPUT.PUT_LINE('Account not found');
                RETURN 0;
            WHEN others THEN
                DBMS_OUTPUT.ENABLE;
                DBMS_OUTPUT.PUT_LINE('Other exception');
                RETURN 0;
                
    END sprawdz_czy_konto_istnieje;
    
    FUNCTION generuj_pozycje RETURN NUMBER
    IS
        rand_x number := DBMS_RANDOM.value(low => 1, high => 10);
        rand_y number := DBMS_RANDOM.value(low => 1, high => 10);
        rand_z number := DBMS_RANDOM.value(low => 1, high => 10);
        map_id number;
        CURSOR map_cursor IS SELECT ID FROM MAPY WHERE rownum = 1;
        maps_not_found EXCEPTION;
        map_found boolean :=false;
        ret_id number;
    BEGIN
        FOR rec IN map_cursor
        LOOP
            map_found := true;
            map_id := rec.ID;
        END LOOP;
        IF map_found = true THEN
            INSERT INTO POZYCJE VALUES(1,rand_x,rand_y,rand_z,map_id) RETURNING ID INTO ret_id;
            RETURN ret_id;
        ELSE
            RAISE maps_not_found;
        END IF;
        EXCEPTION
            WHEN maps_not_found THEN
                DBMS_OUTPUT.ENABLE;
                DBMS_OUTPUT.PUT_LINE('Maps not found');
                RETURN -1;
       
    END generuj_pozycje;
    
    
    FUNCTION generuj_wyglad(plec WYGLAD.SEX%TYPE) RETURN NUMBER
    IS
        g_height number := ROUND(DBMS_RANDOM.value(140, 200));
        g_chest number := ROUND(DBMS_RANDOM.value(20,65));
        g_skin_color varchar(7) :=  '#'||lpad(trim(to_char(floor(dbms_random.value(0,32767)),'XXXXXX')),6,'0');
        g_hair_color varchar(7) :=  '#'||lpad(trim(to_char(floor(dbms_random.value(0,32767)),'XXXXXX')),6,'0');
        g_eye_color varchar(7)  :=  '#'||lpad(trim(to_char(floor(dbms_random.value(0,32767)),'XXXXXX')),6,'0');
        g_hair number := ROUND(DBMS_RANDOM.VALUE(1,3));
        sex_not_found EXCEPTION;
        ret_val number;
    BEGIN
        IF plec = 'm' THEN
            INSERT INTO WYGLAD VALUES(1,plec,g_height,g_chest,g_skin_color,g_hair_color,g_eye_color,g_hair) RETURNING ID INTO ret_val;
            RETURN ret_val;
        ELSIF plec = 'k' THEN
           INSERT INTO WYGLAD VALUES(1,plec,g_height,g_chest,g_skin_color,g_hair_color,g_eye_color,g_hair) RETURNING ID INTO ret_val;
            RETURN ret_val;
        ELSE 
         RAISE sex_not_found;
        END IF;
        EXCEPTION 
            WHEN sex_not_found THEN
                DBMS_OUTPUT.ENABLE;
                DBMS_OUTPUT.PUT_LINE('Sex not found');
                RETURN -1;
                
    END generuj_wyglad;
    
    FUNCTION dodaj_statystyki(klasa number, rasa number) RETURN NUMBER
    IS
        CURSOR klasa_cursor IS SELECT B_STAT_ID FROM KLASY_POSTACI WHERE ID = klasa;
        CURSOR rasa_cursor  IS SELECT B_STAT_ID FROM RASY WHERE ID = rasa;
        g_hp number := 0;
        g_mana number := 0;
        g_str number := 0;
        g_agility number := 0;
        g_int number :=0;
        g_stamina number :=0;
        found_class boolean := false;
        found_race boolean := false;
        not_found_class EXCEPTION;
        not_found_race EXCEPTION;
        b_klasa_id number;
        b_rasa_id number;
        ret_val number;
    BEGIN
        FOR rec_klasa IN klasa_cursor
        LOOP
            found_class := true;
            b_klasa_id := rec_klasa.B_STAT_ID;
        END LOOP;
        FOR rec_rasa in rasa_cursor
        LOOP
            found_race := true;
            b_rasa_id := rec_rasa.B_STAT_ID;
        END LOOP;
        IF found_class = true THEN
            IF found_race = true THEN
                FOR  rec IN (SELECT * FROM BAZOWE_STATYSTYKI WHERE ID = b_klasa_id OR ID = b_rasa_id)
                LOOP
                        g_hp := g_hp +rec.BASE_HP;
                        g_mana := g_mana+rec.BASE_MP;
                        g_str := g_str+rec.BASE_STR;
                        g_agility := g_agility+rec.BASE_AG;
                        g_int := g_int+rec.BASE_INT;
                        g_stamina := g_stamina+rec.BASE_STAMINA;
                 END LOOP rec;
                 INSERT INTO STATYSTYKI VALUES(1,1,g_hp,g_mana,g_str,g_agility,g_int,g_stamina,0) RETURNING ID INTO ret_val;
                 RETURN ret_val;
            ELSE
                RAISE not_found_race;
            END IF;
        ELSE
            RAISE not_found_class;
        END IF;
        EXCEPTION
            WHEN not_found_race THEN
                    DBMS_OUTPUT.ENABLE;
                    DBMS_OUTPUT.PUT_LINE('Race not found');
                    RETURN -1;                
            WHEN not_found_class THEN
                    DBMS_OUTPUT.ENABLE;
                    DBMS_OUTPUT.PUT_LINE('Class not found');
                    RETURN -1;                
    END dodaj_statystyki;
    
    FUNCTION dodaj_postac(acc_id KONTA.ID%TYPE, nick POSTACIE.NICKNAME%TYPE, rasa varchar2, klasa varchar2, plec WYGLAD.SEX%TYPE ) RETURN NUMBER
    IS
        g_stat_id number;
        g_race_id number;
        g_class_id number;
        g_look_id number;
        g_pos_id number;
        is_account_correct NUMBER;
        stat_not_found EXCEPTION;
        race_not_found EXCEPTION;
        class_not_found EXCEPTION;
        look_not_found EXCEPTION;
        pos_not_found EXCEPTION;
        account_not_found EXCEPTION;
        ret_val number;
    BEGIN
        g_race_id := mmo.znajdz_rase(rasa,plec);
        g_class_id := mmo.znajdz_klase(klasa);
        is_account_correct := mmo.sprawdz_czy_konto_istnieje(acc_id);
        g_pos_id := mmo.generuj_pozycje;
        g_look_id := mmo.generuj_wyglad(plec);
        g_stat_id := mmo.dodaj_statystyki(g_class_id,g_race_id);
        
        IF g_stat_id > 0 THEN
            IF g_race_id > 0 THEN
                IF g_class_id > 0 THEN
                    IF g_look_id > 0 THEN
                        IF g_pos_id > 0 THEN
                            IF is_account_correct = 1 THEN
                                INSERT INTO POSTACIE VALUES(1,nick,g_stat_id,acc_id,g_race_id,g_class_id,g_look_id,g_pos_id) RETURNING ID INTO ret_val;
                                RETURN ret_val;
                            ELSE
                                RAISE account_not_found;
                            END IF;
                        ELSE
                            RAISE pos_not_found;
                        END IF;
                    ELSE
                     RAISE look_not_found;
                    END IF;
                ELSE
                    RAISE class_not_found;
                END IF;
            ELSE
                RAISE race_not_found;
            END IF;
        ELSE
            RAISE stat_not_found;
        END IF;
        EXCEPTION 
            WHEN stat_not_found THEN
                    DBMS_OUTPUT.ENABLE;
                    DBMS_OUTPUT.PUT_LINE('Stat not found');
                    RETURN -1;  
            WHEN race_not_found THEN
                    DBMS_OUTPUT.ENABLE;
                    DBMS_OUTPUT.PUT_LINE('Race not found');
                    RETURN -1;  
            WHEN class_not_found THEN
                    DBMS_OUTPUT.ENABLE;
                    DBMS_OUTPUT.PUT_LINE('Class not found');
                    RETURN -1;  
            WHEN look_not_found THEN
                    DBMS_OUTPUT.ENABLE;
                    DBMS_OUTPUT.PUT_LINE('Look not found');
                    RETURN -1;  
            WHEN pos_not_found THEN
                    DBMS_OUTPUT.ENABLE;
                    DBMS_OUTPUT.PUT_LINE('Pos not found');
                    RETURN -1;  
            WHEN account_not_found THEN
                    DBMS_OUTPUT.ENABLE;
                    DBMS_OUTPUT.PUT_LINE('Account not found');
                    RETURN -1;              
    END dodaj_postac;
 

END mmo;",
            @"CREATE OR REPLACE PACKAGE BODY mmo_test AS
PROCEDURE znajdz_rase(good_data boolean)
IS
test_var number;
BEGIN
IF good_data = true THEN
    test_var := mmo.znajdz_rase('human','m');
    DBMS_OUTPUT.ENABLE;
    DBMS_OUTPUT.PUT_LINE('Found'|| test_var);
ELSE
    test_var := mmo.znajdz_rase('test','m');
    DBMS_OUTPUT.ENABLE;
    DBMS_OUTPUT.PUT_LINE('Found'|| test_var);
    test_var := mmo.znajdz_rase('human','a');
    DBMS_OUTPUT.ENABLE;
    DBMS_OUTPUT.PUT_LINE('Found'|| test_var);
END IF;

END znajdz_rase;

PROCEDURE znajdz_klase(good_data boolean)
IS
test_var number;
BEGIN
IF good_data = true THEN
    test_var := mmo.znajdz_klase('warrior');
    DBMS_OUTPUT.ENABLE;
    DBMS_OUTPUT.PUT_LINE('Found '|| test_var);
ELSE
    test_var := mmo.znajdz_klase('test');
    DBMS_OUTPUT.ENABLE;
    DBMS_OUTPUT.PUT_LINE('Found '|| test_var);
END IF;

END znajdz_klase;

PROCEDURE sprawdz_czy_konto_istnieje(good_data boolean)
IS
test_var boolean;
BEGIN
    IF good_data = true THEN
        test_var := mmo.sprawdz_czy_konto_istnieje(1);
        DBMS_OUTPUT.ENABLE;
        IF test_var = true THEN
            DBMS_OUTPUT.PUT_LINE('Exists');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Not exists');
        END IF;
        
    ELSE
        test_var := mmo.sprawdz_czy_konto_istnieje(99);
        DBMS_OUTPUT.ENABLE;
        IF test_var = true THEN
            DBMS_OUTPUT.PUT_LINE('Exists');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Not exists');
        END IF;
    END IF;
END sprawdz_czy_konto_istnieje;

PROCEDURE generuj_pozycje
AS

    test_var number;
BEGIN
    test_var := mmo.generuj_pozycje;
    DBMS_OUTPUT.ENABLE;
    DBMS_OUTPUT.PUT_LINE('Found '|| test_var);
END generuj_pozycje;

PROCEDURE generuj_wyglad(good_data boolean)
IS
    test_var number;  
BEGIN
    IF good_data = true THEN
        test_var := mmo.generuj_wyglad('m');
        DBMS_OUTPUT.ENABLE;
        DBMS_OUTPUT.PUT_LINE('Found '|| test_var);        
    ELSE
        test_var := mmo.generuj_wyglad('a');
        DBMS_OUTPUT.ENABLE;
        DBMS_OUTPUT.PUT_LINE('Found '|| test_var);           
    END IF;
    
    END generuj_wyglad;
    
    PROCEDURE dodaj_statystyki(good_data boolean)
    IS
        test_var number;
    BEGIN
        IF good_data = true THEN
        test_var := mmo.dodaj_statystyki(1,1);
        DBMS_OUTPUT.ENABLE;
        DBMS_OUTPUT.PUT_LINE('Found '|| test_var);             
        ELSE
        test_var := mmo.dodaj_statystyki(90,90);
        DBMS_OUTPUT.ENABLE;
        DBMS_OUTPUT.PUT_LINE('Found '|| test_var);         
        END IF;
    END dodaj_statystyki;
    PROCEDURE dodaj_postac
    IS
    test_val number;
    BEGIN
    test_val:=mmo.dodaj_postac(1,'testujeplsql','human','warrior','m');
    DBMS_OUTPUT.ENABLE;
    DBMS_OUTPUT.PUT_LINE('Found '|| test_val); 
    END dodaj_postac;

END mmo_test;"
        });
    }
}