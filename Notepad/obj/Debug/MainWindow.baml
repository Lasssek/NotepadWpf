   M S B A M L   `   `   `  ����B  >Notepad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NotepadNotepad  5   	       Notepad.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Notepad     5   	     � Icon$  public/icon.ico��5   	    � Title$ Notatnik��5	   	   $	��450��6   $	��800��6'    � 	Resources 5
         FlatButtonStyle �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6(   .�5      ��  � ��
 �����6;   �� 5       � ��
 �����6<   �� 5       � ��$ 0q�60   6<   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   � $��0��6   .+�5      �  � Orientation$ 
Horizontal=�6   .+�5      �� -   5        $
��Plik��5      #��[  6(   $
��30px��6Q   	 � ContextMenu	 5      �� 5      .@�5      m� -   5        $	��New��5   '   $
��Nowy��62   
 m� InputGestureText$
 Ctrl+N��6@   6r   m� 5       -   5        $��	NewWindow��5    '   $��	Nowe okno��68   $
 Ctrl+Shift+N��6K   6�   m� 5!      -   5        $
��Open��5!   '   $��
Otwórz...��63   $
 Ctrl+O��6F   6x   m� 5"      -   5        $
��Save��5"   '   $��Zapisz��63   $
 Ctrl+S��6C   6u   m� 5#      -   5        $��SaveAs��5#   '   $��Zapisz jako...��65   $
 Ctrl+Shift+S��6M   6�   �� 5$      6*   m� 5%      $��Ustawienia strony...��6'   6G   m� 5&      -   5        $��Print��5&   '   $��	Drukuj...��64   $
 Ctrl+P��6G   6y   �� 5'      6*   m� 5(      -   5        $
��Exit��5(   '   $��Zakończ��63   6\   5)      5+      �� 5,      -	   5        $��Edycja��5,      #��[  6*   $
��45px��6S   	 5-      �� 5.      .@�5/      m� $��Cofnij��6'   $
 Ctrl+Z��67   6S   �� 50      6*   m� 51      $��Wytnij��6'   $
 Ctrl+X��67   {�.  6e   m� 52      $��Kopiuj��6'   $
 Ctrl+C��67   {�.  6e   m� 53      $��Wklej��6'   $
 Ctrl+V��66   {�.  6d   m� 54      $��Usuń��6'   $	
 Del��65   {�.  6`   �� 55      6*   m� 56      $)��#Wyszukaj za pomocą usługi Bing...��6'   $
 CTRL+E��6R   {�.  6�   m� 57      $��
Znajdź...��6'   $
 Ctrl+F��6:   {�.  6h   m� 58      $��Znajdź następny��6'   $
 F3��6@   {�.  6j   m� 59      $��Znajdź poprzednie��6'   $
 Shift+F3��6B   {�.  6r   m� 5:      $��
Zamień...��6'   $
 Ctrl+H��6:   6V   m� 5;      $��Przejdź do...��6'   $
 Ctrl+G��6>   6Z   �� 5<      6*   m� 5=      $��Zaznacz wszystko��6'   $
 Ctrl+A��6A   6]   m� 5>      $��Godzina/data��6'   $
 F5��6=   6U   5?      5A      �� 5B      -
   5        $��Format��5B      #��[  6*   $
��50px��6S   	 5C      �� 5D      .@�5E      m� -   5        $��TextWrap��5E   '   $��Zawijanie wierszy��67   6j   m� 5F      $��Czcionka...��6'   6>   5G      5I      �� 5J      -   5        $��Widok��5J      #��[  6)   $
��48px��6R   	 5K      �� 5L      .@�5M      m� $��Powiększenie��6'   .@�5N   "   m� $��	Powiększ��6+   $
 	Ctrl+Plus��6=   6\   m� 5O   "   $��	Pomniejsz��6+   $
 
Ctrl+Minus��6>   6^   m� 5P   "   $(��"Przywróć powiększenie domyślne��6+   $
 Ctrl+0��6S   6o   5Q      m� 5R      $��Pasek stanu��6'   6>   5S      5U      �� 5V      -   5        $��Pomoc��5V      #��[  6)   $
��50px��6R   	 5W      �� 5X      .@�5Y      m� $��Wyświetl Pomoc��6'   6A   m� 5Z      $��Wyślij opinię��6'   6@   �� 5[      6*   m� 5\      $��Notatnik - informacje��6'   6H   5]      5_      5`      5a      � 5b   
   $��1��6   .+�5c      �� -   5        $��notepadScroll��5c      $��Visible=�60   $��Visible=�6V   .��5d      �� -   5         ��Name$ notepadTextBox��5d      .��6t   ��5e      �� 5f      " ��6    .�5g      ��  � �� 5h   "   �� 5i   &    �� 
TargetType" ��66   .R�5j   *   ��  ��Name$ border��5k   -   ���#f0f0f0$��
0, 2, 0, 0q�5m   -   #��z��5n   -   ._�5o   .   ��  ��Name$ PART_ContentHost��5p   -   |�.  $��Disabled=�5r   -   $��Disabled=�5s   -   5t   /   5u   +   5v   '   5x      5y      .��5z   %   5{      5}      5~      5      5�      