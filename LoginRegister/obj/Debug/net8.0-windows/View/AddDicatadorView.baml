   M S B A M L   `   `   `  ����H  DLoginRegister, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:LoginRegister.ViewLoginRegister.View  5      A%clr-namespace:LoginRegister.ViewModelLoginRegister.ViewModel  5	      )    #LoginRegister.View.AddDicatadorView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:LoginRegister.View     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      6
viewmodels%clr-namespace:LoginRegister.ViewModel  5	      
���   �$	��350��5      $	��400��6%     � Title$  Añadir Dictador��5      .��5      � $��Center=�6   $��Center=�6&   $	��446��6C   $	��400��6P    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Añadir Producto��5      $��28(�5      $��SemiBold"�5       
�������$��Center=�5"      $��	0,20,0,20q�5#      $��0��5$      �� 5'   
   $��Nombre de Producto��5(      
�������$��Center=�5*      $
��Left=�5+      $��	127,0,0,0q�5,      $��14(�5-       J� IsHitTestVisible$ False��5.      $��1��5/        Wpf.Ui.Controls.TextBox  50   
   
�������$��	44,5,60,5q�52      ���#4A90E2$��1q�54   #   $
��10,5q�67   $��14(�6F   $��2��55      ��53      �� *Nombre+ �� Mode$ TwoWay=�.��55       J� Effect 56      3  -System.Windows.Media.Effects.DropShadowEffect  57         Color$ Black��6#      	Direction$	 270Q�61      
BlurRadius$ 5Q�6A      ShadowDepth$ 2Q�6P   .��58   !   59      �� 5<   
   $��Precio��5=      
�������$��Center=�5?      $
��Left=�5@      $��	173,0,0,0q�5A      $��14(�5B      $ False��5C      $��3��5D        5E   
   
�������$��	44,4,60,6q�5G      ���#4A90E2$��1q�5I   #   $
��10,5q�67   $��14(�6F   $��4��5J      ��5H      �� *Precio+$ TwoWay=�.��5J       5K        5L      $ Black��6#   $	 270Q�61   $ 5Q�6A   $ 2Q�6P   .��5M   !   5N        Wpf.Ui.Controls.Button  5T   
   $��Añadir Producto��5V      
���   �
�������$	��200��5Z      $��50��5[      $
��Left=�5\      $	��Top=�5]      $��5��5^      $��	92,51,0,0q�5_      	   CornerRadius$	 25��5`      $��16(�5a      ��5U      �� *
AddCommand+$ OneWay=�
   Icon
 5W      '  !Wpf.Ui.Markup.SymbolIconExtension     Symbol$ Add20=� 5b        5c      $ Black��6#   $	 270Q�61   $ 10Q�6A   $ 4Q�6Q   5e      5g      5h      