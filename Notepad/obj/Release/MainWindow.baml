   M S B A M L   `   `   `  ���� B  >Notepad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NotepadNotepad      Notepad.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Notepad       � Icon$  public/icon.ico�� � Title$ Notatnik��$	��450��$	��800�� � 	Resources    FlatButtonStyle �� 
TargetType �� Property �� Value��%\   &	        �� " ��.���  � ��
 �������  � ��
 �������  � ��$ 0q�.���  � ColumnDefinitions ��  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+�� $��0��.+��  � Orientation$ 
Horizontal=�.+��� -   $
��Plik��#��[  $
��30px��	 � ContextMenu	 �� .@�m� -   $	��New��$
��Nowy��
 m� InputGestureText$
 Ctrl+N��m� -   $��	NewWindow��$��	Nowe okno��$
 Ctrl+Shift+N��m� -   $
��Open��$��
Otwórz...��$
 Ctrl+O��m� -   $
��Save��$��Zapisz��$
 Ctrl+S��m� -   $��SaveAs��$��Zapisz jako...��$
 Ctrl+Shift+S���� m� $��Ustawienia strony...��m� -   $��Print��$��	Drukuj...��$
 Ctrl+P���� m� -   $
��Exit��$��Zakończ���� -	   $��Edycja��#��[  $
��45px��	 �� .@�m� $��Cofnij��$
 Ctrl+Z���� m� $��Wytnij��$
 Ctrl+X��{�.  m� $��Kopiuj��$
 Ctrl+C��{�.  m� $��Wklej��$
 Ctrl+V��{�.  m� $��Usuń��$	
 Del��{�.  �� m� $)��#Wyszukaj za pomocą usługi Bing...��$
 CTRL+E��{�.  m� $��
Znajdź...��$
 Ctrl+F��{�.  m� $��Znajdź następny��$
 F3��{�.  m� $��Znajdź poprzednie��$
 Shift+F3��{�.  m� $��
Zamień...��$
 Ctrl+H��m� $��Przejdź do...��$
 Ctrl+G���� m� $��Zaznacz wszystko��$
 Ctrl+A��m� $��Godzina/data��$
 F5���� -
   $��Format��#��[  $
��50px��	 �� .@�m� -   $��TextWrap��$��Zawijanie wierszy��m� $��Czcionka...���� -   $��Widok��#��[  $
��48px��	 �� .@�m� $��Powiększenie��.@�m� $��	Powiększ��$
 	Ctrl+Plus��m� $��	Pomniejsz��$
 
Ctrl+Minus��m� $(��"Przywróć powiększenie domyślne��$
 Ctrl+0��m� $��Pasek stanu���� -   $��Pomoc��#��[  $
��50px��	 �� .@�m� $��Wyświetl Pomoc��m� $��Wyślij opinię���� m� $��Notatnik - informacje��� $��1��.+��� -   $��notepadScroll��$��Visible=�$��Visible=�.���� -    ��Name$ notepadTextBox��.������ " ��.���  � �� ��  �� 
TargetType" ��.R���  ��Name$ border�����#f0f0f0$��
0, 2, 0, 0q�#��z��._���  ��Name$ PART_ContentHost��|�.  $��Disabled=�$��Disabled=�.��