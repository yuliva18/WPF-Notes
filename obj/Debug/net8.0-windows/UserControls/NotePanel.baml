   M S B A M L   `   `   `  ����@  <Notes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Notes.UserControlsNotes.UserControls  5      "    Notes.UserControls.NotePanel   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Notes.UserControls     5      -   5          >�Name$  Control��5      .��5
      � -   5         �Name$ grid1��5
   6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $��label1��5      $��1��6   .��5      �� $��CharacterEllipsis=�6_   $��14(�6�   $��DemiBold"�6�   ��6   �� *Title+ �� ElementName$ Control�� �� FallbackValue$ Заголовок��6�   5      �� 5   
   -   5        $��label2��5      $��2��6   .��5      �� $��CharacterEllipsis=�6Z   ��6   �� *Body+$ Control��$ 
Текст��6Z   5      �� 5   
   -   5        $��label3��5      $��3��6b   ���	#FF7B7B7B��6   �� *Date+$ Control��$ Дата��6o   5      ��5      �� 5   
    �� 
TargetType" >�6   .�5      ��  �� Property � �� �� Value
 �����6+    �� Triggers 5      P� 5      "   Notes.UserControls.NotePanel	 P� Property	 �@ 
IsSelected
 P� Value$

 True��6@   . �5      ��  � �� �	#FFE6E6E663   5       P� 5!      	 �@ 
IsSelected$
 False��6@   . �5"      ��  � ��
 �����63   5#      5%      5'      