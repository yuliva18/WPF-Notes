   M S B A M L   `   `   `  ����@  <Notes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:NotesNotes  5   	   3clr-namespace:Notes.ConvertersNotes.Converters  5   	   7 clr-namespace:Notes.UserControlsNotes.UserControls  5   	       Notes.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Notes     5   	   -cvclr-namespace:Notes.Converters     5   	   /uc clr-namespace:Notes.UserControls     5   	     � Title$  Notes��5
   	   $	��450��6   $	��800��6$    � 	Resources 5      4   .Notes.Converters.FlowDocumentToStringConverter !  FlowDocumentToStringConverter0  *Notes.Converters.BoolToVisibilityConverter  BoolToVisibilityConverter��%:   &	        &	        5   
   6+     5   
   6'   5      .��5      � $
��10pt(�6    � ColumnDefinitions 5   
   �� 5      $��* �6   $	��300��6)   �� 5      $��3* �6   .+�5   
   �� $��Visible=�6   $��0��6=   .��5      �  � RowDefinitions 5      �� 5      $
��auto �6$   $��40��62   �� 5      $��* �6$   .+�5      �� -   5        $��Новая заметка��5      $��0��61   6>   �� 5      -   5        $��
NotePanels��5   F   $��1��6X   ��6   �� *NoteCollection+��5      �� 5      .R�5      "   Notes.UserControls.NotePanel  "   Notes.UserControls.NotePanel   Click onCl6@  $	��100��6+   $��0��68      Title 6H   �� *Title+ �� Mode$ TwoWay=� �� 	Converter# [     Body 6�   �� *Body+$ TwoWay=�# [  	   Date	 6  �� *Date+
   
IsSelected
 6  �� *
IsSelected+	   Id 6M  �� *Id+5      5!      5"      5#      � 5$   
   $��1��6   ���	#FFDDDDDD 5%      �� 5&      $
��auto �6    $��40��6.   �� 5'      $��* �6    .+�5)      �� $��Visible=�6   $��1��6A   .��5*      �  5+      �� 5,      $��40��6(   $
��Auto �67   �� 5-      $��* �6(   .+�5/      �� -   5         ��Name$ textbox1��5/   "   $��0��64    �� AcceptsReturn$
 True��6c   y�6�   �� *IsCollectionNonEmpty+# [ �� 50      -   5        $ textbox2��50   "   $��1��64   $
 True��6d   y�6�   �� *IsCollectionNonEmpty+# [ 51      52      � 53      $��0��6    54      �� 55      $
��auto �6'   �� 56      $
��auto �6'   �� 57      $
��auto �6'   �� 58      $
��auto �6'   �� 59      $��* �6'   �� 5:      $
��auto �6'   .+�5<      �� -   5        $��0��5<      $��Ж��6)   $
��Bold"�65   $��24��6G   $��24��6S   $	��5,0q�6^   $|�False��6�   �� 5=      -   5        $��1��5=      $��К��6)   $��Italic$�65   $��24��6H   $��24��6T   $��0,0,5,0q�6_   $|�False��6�   �� 5>      $��2��6   $!��Размер шрифта: ��6(   $��Center=�6B   (   "Notes.UserControls.FontSizeChanger  5?      $��3��6%   $	��150��6a   $��24��6p      Range 65   �� *SelectedText+$ TwoWay=�6p   �� 5@      -   5        $��5��5@      $#��Удалить заметку��6)   $	��120��6C   $|�False��6c   5A      5B      5D      5E      