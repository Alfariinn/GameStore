# GameStore


Działają przyciski na controlbarze, przycisk login przenosi uzytkownika na drugie okno, reszta funkcjonalności nie istnieje.
Baza danych jest w plikach, ale droga do niej została zapisana lokalnie więc kompilator może jej nie rozpoznać na innym urządzeniu
w takmi wypadku trzeba zmienić ją ręcznie w pliku GameStoreDBContext.cs w folderze Data. 
Do wygenerowania odpowiednich klas na podstawie bazy danych użyłem meotdy reverse enginering z pomocą EntityFrameworkCore.Sqlite i EntityFrameworkCore.Tools
