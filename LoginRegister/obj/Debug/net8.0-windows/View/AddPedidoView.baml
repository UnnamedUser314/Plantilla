   M S B A M L   `   `   `  ����H  DLoginRegister, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:LoginRegister.ViewLoginRegister.View  5   	   &     LoginRegister.View.AddPedidoView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hui9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   2local clr-namespace:LoginRegister.View     5   	     � Title$  AddPedidoView��5	   	   $	��450��6   $	��800��6,   
���   �.��5      � $��Center=�6   $��Center=�6&   $	��446��6C   $	��400��6P    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Añadir Pedido��5      $��28(�5      $��SemiBold"�5      
�������$��Center=�5      $��	0,20,0,20q�5      $��0��5       �� 5#   
   $��Fecha��5$      
�������$��Center=�5&      $
��Left=�5'      $��	174,0,0,0q�5(      $��14(�5)       J� IsHitTestVisible$ False��5*      $��1��5+      (  "System.Windows.Controls.DatePicker  5.   
   -   5        $��myDatePicker��50      $	��200��51      $
��Left=�52      $	��Top=�53      $��4��54      $��2��55      $��96,5,0,0q�56         SelectedDate 5/      �� *SelectedDate+ �� Mode$ TwoWay=�56      �� 58   
   $��Usuario��59      
�������$	��Top=�5;      $
��Left=�5<      $��
168,42,0,0q�5=      $��14(�5>      $ False��5?      $��5��5@      �� 5B   
   $
��Left=�5C   8   $��Center=�6S   $	��200��6n   $	��150��6z   $��92,0,0,0q�6�   $��5��6�   ��5B      �� *Items+ �� SelectedItem 5C      �� *SelectedItem+��5D      �� 5E      .R�5F      ��  �� Padding$ 10q�61   ��6    �� 61   5G      5I      �� 5P   
   $��Añadir Pedido��5R      
���   �
�������$	��200��5U      $��50��5V      $
��Left=�5W      $	��Top=�5X      $��5��5Y      $��
92,231,0,0q�5Z      $��16(�5[      ��5Q      �� *
AddCommand+$ OneWay=� J� Effect 5\      3  -System.Windows.Media.Effects.DropShadowEffect  5]         Color$ Black��6#   	   	Direction$		 270Q�61   
   
BlurRadius$
 10Q�6A      ShadowDepth$ 4Q�6Q   5_      5a      5b      