   M S B A M L   `   `   `  ����H  DLoginRegister, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:LoginRegister.ViewLoginRegister.View  5   	   0    *LoginRegister.View.AddProductoToPedidoView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:LoginRegister.View     5   	   Hui9http://schemas.microsoft.com/winfx/2006/xaml/presentation     68     � Title$  AddProductoToPedidoView��5   	   $	��450��6)   $	��800��66   
���   �.��5
      � $��Center=�6   $��Center=�6&   $	��446��6C   $	��400��6P    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Añadir Producto��5   	   $��28(�5   	   $��SemiBold"�5   	   
�������$��Center=�5   	   $��	0,20,0,20q�5   	   $��0��5   	   �� 5"   
   $��Nombre de Producto��5#   	   
�������$��Center=�5%   	   $
��Left=�5&   	   $��	127,0,0,0q�5'   	   $��14(�5(   	    J� IsHitTestVisible$ False��5)   	   $��1��5*   	   �� 5+   
   
�������$��	44,5,60,5q�5-   	   ���#4A90E2$��1q�5/      $
��10,5q�63   $��14(�6B   $��2��50   	   ��5.   	   �� *Nombre+ �� Mode$ TwoWay=�.��50       J� Effect 51      3  -System.Windows.Media.Effects.DropShadowEffect  52         Color$ Black��6#      	Direction$	 270Q�61      
BlurRadius$ 5Q�6A      ShadowDepth$ 2Q�6P   .��53   !   54      �� 5=   
   $��Añadir Producto��5?   	   
���   �
�������$	��200��5B   	   $��50��5C   	   $
��Left=�5D   	   $	��Top=�5E   	   $��5��5F   	   $��	92,51,0,0q�5G   	   $��16(�5H   	   ��5>   	   �� *
AddCommand+$ OneWay=� 5I        5J      $ Black��6#   $	 270Q�61   $ 10Q�6A   $ 4Q�6Q   5L      5N      5O      