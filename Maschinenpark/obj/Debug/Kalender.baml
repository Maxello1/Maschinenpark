   M S B A M L   `   `   `  ����H  DMaschinenpark, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MaschinenparkMaschinenpark  5          Maschinenpark.Kalender   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Maschinenpark     5        N� Title$  Kalender��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��275* �6   �� 5      $	��48* �6   �� 5      $
��757* �6   .+�5   
   �� -   5         ��Name$ labelProject��5      $��Maschinenpark��6&   $��
43,4,0,201q�6>   $��45(�6R   
�������$
��Left=�6s   $	��319��6�   ���	#FF4242426�   �� 5   
   -   5         ��Name$ 	btn_login��5      $��Abmelden��6$   $��1790,10,30,233q�67    � Cursor$
 Hand��6O   $��17(�6]   $	��100��6k   $��32��6w   ��5      �� 5       �� EndPoint$	 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5      �  � Color$ 	#FFF3F3F3��6#    � Offset$ 0Q�65   � 5      $ 	#FFEBEBEB��6#   $ 1Q�65   � 5      $ 	#FFDDDDDD��6#   � 5      $ 	#FFCDCDCD��6#   $ 1Q�65   5      5      �� 5   
   $��Maschinennummer:��6   $
��Left=�6+   $��
46,103,0,0q�6F   $	��Top=�6Z   
���   �
�������$��18(�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        	  Name$	 datePickerField��5      $
��Left=�6.   $��
49,153,0,0q�6I   $	��Top=�6]   $	��183��6u   
���   �$��18(�6�   $��2,2,-1,2q�6�   
   SelectedDateFormat$
 Short=�6�   $��0q�6�   $��23��6�      IsTodayHighlighted .    IsDropDownOpen .  ��5      �� 5       $ 0.5,0&�6&   $ 0.5,1&�67   .��5!      � $ 	#FFA3AEB9��6#   $ 0Q�65   � 5"      $ White��6#   $ 1Q�61   � 5#      $ 	#FF718597��6#   � 5$      $ White��6#   5%      5(      �� 5)   
   $	��Von��6   $
��Left=�6   $��
46,192,0,0q�69   $	��Top=�6M   
�������$��18(�6x   $��45��6�   �� 5*   
   -   5         ��Name$ vonHH��5*      $
��Left=�6!   $��31��6<   $��
91,194,0,0q�6H    �� 	MaxLength$ 2��6\    �� TextWrapping$
 Wrap=�6j   $��07��6~   $	��Top=�6�   $��26��6�   $��18(�6�   $��0q�6�   62  �� 5+   
   -   5        $ vonSS��5+      $
��Left=�6!   $��31��6<   $��131,194,0,0q�6H   $ 2��6]   $
 Wrap=�6k   $��30��6   $	��Top=�6�   $��29��6�   $��18(�6�   $��0q�6�   63  �� 5,   
   $	��Uhr��6   $
��Left=�6   $��167,192,0,0q�69   $	��Top=�6N   
�������$��18(�6y   �� 5-   
   $	��Bis��6   $
��Left=�6   $��
46,236,0,0q�69   $	��Top=�6M   
�������$��18(�6x   $��45��6�   �� 5.   
   -   5        $ bisHH��5.      $
��Left=�6!   $��32��6<   $��
91,238,0,0q�6H   $ 2��6\   $
 Wrap=�6j   $��15��6~   $	��Top=�6�   $��26��6�   $��18(�6�   $��0q�6�    J� RenderTransformOrigin$ -0.135,0.547&�62  6W  �� 5/   
   -   5        $ bisSS��5/      $
��Left=�6!   $��32��6<   $��131,238,0,0q�6H   $ 2��6]   $
 Wrap=�6k   $��15��6   $	��Top=�6�   $��29��6�   $��18(�6�   $��0q�6�   6  �� 50   
   $	��Uhr��6   $
��Left=�6   $��167,236,0,0q�69   $	��Top=�6N   
�������$��18(�6y   �� 51   
   $��:��6   $
��Left=�6   $��117,190,0,0q�67   $	��Top=�6L   
�������$��18(�6w   $��14��6�   $��35��6�   �� 52   
   $��:��6   $
��Left=�6   $��117,234,0,0q�67   $	��Top=�6L   
�������$��18(�6w   $��14��6�   $��36��6�   �� 53   
   -   5        $ labelMN��53      $�� ��6!   $��887,10,0,195q�6,   $��30(�6B   
�������$
��Left=�6c   $	��304��6~   ���	#FF4242426�   �� 54   
   -	   5        $ labelKW��54      $�� ��6!   $��914,75,0,130q�6,   $��30(�6B   
�������$
��Left=�6c   $	��256��6~   ���	#FF4242426�   �� 55   
   -
   5        $ 	btnKWBack��55      $
��Left=�6%   $��
868,86,0,0q�6@   $	��Top=�6T   $��34��6l   $��32��6w   $��17(�6�   
�������
�������$��0q�6�   .��56      �� $��28��6   $'��!1489408217_icon-arrow-right-b.jpg��6    $
��Fill=�6K   $��29��6Z   $ 1.862,0.628&�6e   z�57      V� 58      .~�59      �� �� 5:      �� 5;       �� Angle$ -179.873Q�6*   T� 5<       T� X$ -78.988Q�6-    T� Y$ -7.249Q�69   5=      5?      5@      �� 5A   
   -   5        $ btnMachineBack��5A      $
��Left=�6)   $��
843,21,0,0q�6D   $	��Top=�6X   $��34��6p   $��33��6{   $��17(�6�   $��0q�6�   
���������5B      �� 5C       �� Color$ White��6"    �� Opacity$ 0Q�60   .��5E      �� $��28��6   $'��!1489408217_icon-arrow-right-b.jpg��6    $
��Fill=�6K   $��29��6Z   $ 0.5,0.5&�6e   z�5F      V� 5G      .~�5H      �� �� 5I      �� 5J      $ -179.873Q�6*   T� 5K      5L      5N      5O      �� 5P   
   -   5        $ 	kWforward��5P      $
��Left=�6$   $��1175,85,0,0q�6?   $	��Top=�6T   $��34��6l   $��33��6w   $��17(�6�   $��0q�6�   ��6�   Z�  J� OpacityMask 5Q      �� 5R      $ 0.5,1&�6&   $ 0.5,0&�67   .��5S      � $ Black��6#   $ 0Q�61   � 5T      $ White��6#   5U      ��5W      �� 5X      $	 0,1&�6&   $	 0,0&�65   .��5Y      � $ 	#FFF3F3F3��6#   $ 0Q�65   � 5Z      $ 	#FFEBEBEB��6#   � 5[      $ 	#FFDDDDDD��6#   � 5\      $ White��6#   5]      .��5_      �� $��28��6   $'��!1489408217_icon-arrow-right-b.jpg��6    $
��Fill=�6K   $��29��6Z   $ 1.207,0.522&�6e   z�5`      V� 5a      .~�5b      �� �� 5c      �� 5d      $ -359.87Q�6*   T� 5e      $ -0.002Q�6-   $ 0.055Q�68   5f      5h      5i      �� 5j   
   -   5        $ btnMachineForwoard��5j      $
��Left=�6.   $��1202,21,0,0q�6I   $	��Top=�6^   $��34��6v   $��33��6�   $ -0.441,0.636&�6�   $��17(�6�   $��0q�6�   ��5k      �� 5l      $ 0.5,1&�6&   $ 0.5,0&�67   .��5m      � $ Black��6#   $ 0Q�61   � 5n      $ White��6#   5o      ��5q      �� 5r      $	 0,1&�6&   $	 0,0&�65   .��5s      � $ 	#FFF3F3F3��6#   $ 0Q�65   � 5t      $ 	#FFEBEBEB��6#   � 5u      $ 	#FFDDDDDD��6#   � 5v      $ White��6#   5w      .��5y      �� $��28��6   $'��!1489408217_icon-arrow-right-b.jpg��6    $
��Fill=�6K   $��29��6Z   $ 0.5,0.5&�6e   z�5z      V� 5{      .~�5|      �� �� 5}      �� 5~      $ -360.068Q�6*   T� 5      5�      5�      5�      �� 5�   
   -   5        $ 
addEintrag��5�      $��	Speichern��6&   $
��Left=�6:   $��49,8,0,0q�6U   $	��Top=�6g   $��88��6   $��18(�6�   $��1��6�   �� 5�   
   -   5         ��Name$ 
comboBoxMN��5�      $
��Left=�6'   $��213,108,0,0q�6B   $	��Top=�6W   $��43��6o   $��28��6z    �� SelectedIndex$ 0��6�   $��15(�6�   $
 Hand��6�   5�      �� 5�   
   -   5        $ 	labelTipp��5�      $�� ��6#   $
��Left=�6.   $��46,8,0,0q�6I   $	��Top=�6[   $	��316��6s   
�������
���  ��$��16(�6�   $��2��6�   �� 5�   
   -   5        $ labelUsername��5�      $�� ��6'   $��Right=�62   $
��Left=�6U   $��1411,10,0,0q�6p   $	��Top=�6�   $��30��6�   $	��374��6�   
�������$��17(�6�   �� 5�   
   $��414,-299,1504,-255q�6   $��cutline.jpg��6,   $
��Fill=�6A   $��3��6P   �� 5�   
   -   5         ��Name$ EntryDeleteListBox��5�      
�������$��47,112,1581,87q�6C   $y�Visible=�6[   ���	#FF688CAF���	#FF444444 K� ZIndex$	 100��6�   $��18(�6�   $��2��6�   $��2,2,0,0q�6�   $��Center=�6�   $ �� IsSynchronizedWithCurrentItem$ FalseY�6  $	��292��6(  $	��558��67  $	��292��6G  $	��558��6V  �� 5�   
   -   5        $ MachineUnusedLIstBox��5�      
�������$��47,112,1581,52q�6D   $y�	Collapsed=�6\   ���	#FF688CAF���	#FF444444$	 100��6�   $��18(�6�   $��2,2,0,0q�6�   $��2��6  $	��292��6  $	��593��6*  $	��292��6:  $	��593��6I  &   System.Windows.Controls.DataGrid  5�   
   -   5          Name$ DataGridMonday��5�      $
��Left=�6,   |�.  $��491,228,0,0q�6Y   $	��Top=�6n   $	��800��6�   $	��270��6�   $��18(�6�      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����
�������$ FalseY�6    J� IsHitTestVisible .     CanUserReorderColumns  .  !   CanUserResizeColumns! .  "   CanUserSortColumns" .  #   MinColumnWidth$	# 230Q�6�  $   CanUserResizeRows$ .  %   
IsReadOnly% . &   EnableRowVirtualization& .  '   SelectionMode$' Single=�6�  (   SelectionUnit$( CellOrRowHeader=�6  )   HeadersVisibility$) Column=�6,  * J� 	AllowDrop* .  +   GridLinesVisibility$
+ None=�6Z  ,   AreRowDetailsFrozen, . $��3��6�    5�   
   -   5        $ DataGridTuesday��5�      $
��Left=�6,   $��761,228,0,0q�6G   $	��Top=�6\   $	��800��6t   $	��270��6�   $��18(�6�   
 �����
 �����
�������$ FalseY�6�    . |�.    .  ! .  " .  $	# 225Q�6�  $ .  % . & .  $' Single=�6�  $
( Cell=�6  $) Column=�6!  $��3��6<    5�   
   -   5        $ DataGridWednesday��5�      $
��Left=�6.   $��1031,228,0,0q�6I   $	��Top=�6_   $	��800��6w   $	��270��6�   $��18(�6�   
 �����
 �����
�������$ FalseY�6�    . |�.    .  ! .  " .  $	# 225Q�6�  $ .  % . & .  $' Single=�6�  $
( Cell=�6  $) Column=�6$  $��3��6?    5�   
   -   5        $ DataGridThursday��5�      $
��Left=�6-   $��1301,228,0,0q�6H   $	��Top=�6_   $	��800��6w   $	��270��6�   $��18(�6�   
 �����
 �����
�������$ FalseY�6�    . |�.    .  ! .  " .  $	# 225Q�6�  $ .  % . & .  $' Single=�6�  $
( Cell=�6  $) Column=�6$  $��3��6?    5�   
   -   5        $ DataGridFriday��5�      $
��Left=�6+   $��1571,228,0,0q�6F   $	��Top=�6\   $	��800��6t   $	��270��6�   $��18(�6�   
 �����
 �����
�������$ FalseY�6�    . |�.    .  ! .  " .  $	# 225Q�6�  $ .  % . & .  $' Single=�6�  $
( Cell=�6  $) Column=�6!  $��3��6<  �� 5�   
   -   5        $ kwDaysDatum��5�      $�� ��6%   $��Center=�60   $
��Left=�6T   $��914,128,0,0q�6o   $	��Top=�6�   $	��252��6�   
�������$��18(�6�   �� 5�   
   -   5        $ delete��5�      $��Löschen��6!   - � ToolTip$8- 2Zwischen der Tabelle Suchen und Löschen wechseln.��63   $
��Left=�6o   $��	150,8,0,0q�6�   $	��Top=�6�   $��88��6�   $��30��6�   $��18(�6�   $��1��6�   �� 5�   
   -   5        $ suche��5�      $��Suchen��6    $8- 2Zwischen der Tabelle Suchen und Löschen wechseln.��61   $
��Left=�6m   $��	251,8,0,0q�6�   $	��Top=�6�   $��88��6�   $��30��6�   $��18(�6�   $��1��6�     5�   
   -   5        $ DataGridVorschlag��5�      $y�Hidden=�6.   $
��Left=�6D   $��	49,71,0,0q�6_   $	��Top=�6r   $	��634��6�   $	��282��6�   $��18(�6�   
 �����
 �����
�������$ FalseY�6   .   .  ! .  " .  $	# 255Q�6�  $ .  % . & .  $' Single=�6�  $( CellOrRowHeader=�6  $) Column=�60  |�.  * .  $
+ None=�6o  , . $��2��6�  �� 5�   
   -   5        $ LabelLeftCenter��5�      $��Eigene Einträge��6)   $
��Left=�6C   $��	46,72,0,0q�6^   $	��Top=�6q   $��40��6�   $	��193��6�   $��18(�6�   
�������$��2��6�   �� 5�   
   -   5        $ DeleteEntry��5�      $N- HEintrag aus Tabelle wählen und hier klicken um den Eintrag zu löschen.��6&   $��Löschen��6w   $y�Visible=�6�   $
��Left=�6�   $��
47,675,0,0q�6�   $	��Top=�6�   $	��292��6�   $��18(�6�   $��2��6  �� 5�   
   -   5        $ btnMachineBack_Copy��5�      $
��Left=�6/   $��
187,78,0,0q�6J   $	��Top=�6^   $��23��6v   $��23��6�   $��17(�6�   $��0q�6�   
�������$ 2��6�   $��2��6�   ��5�      �� 5�      $ White��6"   $ 0Q�60   .��5�      �� $��10��6   $��
arrowS.jpg��6    $
��Fill=�64   $��7��6C   $ 0.5,0.5&�6M   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ -179.873Q�6*   T� 5�      5�      5�      5�      �� 5�   
   -    5        $ KWLabel��5�      $��KW��6!   $
��Left=�6.   $��
206,72,0,0q�6I   $	��Top=�6]   $��17(�6u   
�������$ 1��6�   $��40��6�   $��2��6�   �� 5�   
   -!   5        $ btnMachineBack_Copy1��5�      $
��Left=�60   $��
239,78,0,0q�6K   $	��Top=�6_   $��23��6w   $��23��6�   $��17(�6�   $��0q�6�   
�������$ 2��6�   $��2��6�   ��5�      �� 5�      $ White��6"   $ 0Q�60   .��5�      �� $��10��6   $��
arrowS.jpg��6    $
��Fill=�64   $��7��6C   $ 0.5,0.5&�6M   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ -0.369Q�6*   T� 5�      5�      5�      5�      �� 5�   
   -"   5        $ MNLabel��5�      $��MN��6!   $
��Left=�6.   $��
282,72,0,0q�6I   $	��Top=�6]   $��17(�6u   
�������$ 1��6�   $��40��6�   $��2��6�   �� 5�   
   -#   5        $ btnMachineBack_Copy2��5�      $
��Left=�60   $��
316,78,0,0q�6K   $	��Top=�6_   $��23��6w   $��23��6�   $��17(�6�   $��0q�6�   
�������$ 2��6�   $��2��6�   ��5�      �� 5�      $ White��6"   $ 0Q�60   .��5�      �� $��10��6   $��
arrowS.jpg��6    $
��Fill=�64   $��7��6C   $ 0.5,0.5&�6M   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ -0.369Q�6*   T� 5�      5�      5�      5�      �� 5�   
   -$   5        $ btnMachineBack_Copy3��5�      $
��Left=�60   $��
262,78,0,0q�6K   $	��Top=�6_   $��23��6w   $��23��6�   $��17(�6�   $��0q�6�   
�������$ 2��6�   $��2��6�   ��5�      �� 5�      $ White��6"   $ 0Q�60   .��5�      �� $��10��6   $��
arrowS.jpg��6    $
��Fill=�64   $��7��6C   $ 0.5,0.5&�6M   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ -179.873Q�6*   T� 5�      5�      5�      5�      5�      5�      