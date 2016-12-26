# Episode-names
Program to rename your files. Anisearch functions (search and get episode names) included

Funktionen:
Number: Durchnummerieren der Dateien

Anisearch: Episodenliste wird von Anisearch geholt. Anisearch-Suche ist im Programm integriert.

Get-Filenames: Damit werden die Dateinamen aus dem angegebenen Ordner geholt. (Nützlich wenn man nur bestimmte Teile des Namens benötigt)

Format-String: Hier wird angegeben wie das Formatierte ausschauen soll

Split-String: Hier wird angegeben wonach jede Spalte in der TextBox aufgeteilt werden soll. Es können auch mehrere Befehle eingetragen werden, diese werden mit | getrennt.

Copy-Listener: Wenn dieser aktiviert ist, werden zukünftige Daten in der Zwischenablage jeweils in eine Zeile geschrieben (also pro STRG + C)

Search & Replace: Sucht im angegebenen Pfad nach einem Text und ersetzt ihn durch einen anderen (z.B. Alle Punkte der Dateinamen im angegebenen Pfad werden durch Leerzeichen ersetzt "Das.ist.mein.Dateiname.mkv" zu "Das ist mein Dateiname.mkv")

Insert Position: fügt bei der angegebenen Position den angegebenen Text ein

Delete Positions: löscht die Zeichen auf den angegebenen Positionen (die Positionen schreibt man daneben in das Textfeld). Positionen werden mit ";" getrennt und es kann auch von-bis angegeben werden. Also z.B. "1,5,7-10", dann werden die Zeichen auf den Positionen 1,5,7,8,9,10 gelöscht.
