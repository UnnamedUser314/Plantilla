   M S B A M L   `   `   `  ����H  DLoginRegister, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:LoginRegister.ViewModelLoginRegister.ViewModel  5   	   C&clr-namespace:LoginRegister.ConvertersLoginRegister.Converters  5   	   7 clr-namespace:LoginRegister.ViewLoginRegister.View  5   	       LoginRegister.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;	viewModel%clr-namespace:LoginRegister.ViewModel     5   	   =
converters&clr-namespace:LoginRegister.Converters     5   	   1view clr-namespace:LoginRegister.View     5   	     � Title$  LoginRegister��5
   	   $	��450��6   $	��800��6,   ��5      �� 5   
    �� ImageSource$ /Resources/GreenBG.png��6    j� Stretch$ UniformToFill=�6:    � 	Resources 5      ;   5LoginRegister.Converters.BooleanToVisibilityConverter   BoolToVisibility8   2LoginRegister.Converters.BoolToGridLengthConverter  BoolToGridLengthConverter �� DataType0   *LoginRegister.ViewModel.DashboardViewModel&    LoginRegister.View.DashboardView3   -LoginRegister.ViewModel.AddDicatadorViewModel)   #LoginRegister.View.AddDicatadorView,   &LoginRegister.ViewModel.LoginViewModel"   LoginRegister.View.LoginView/	   )LoginRegister.ViewModel.RegistroViewModel%
   LoginRegister.View.RegistroView/   )LoginRegister.ViewModel.DetallesViewModel%   LoginRegister.View.DetallesView2   ,LoginRegister.ViewModel.InformacionViewModel(   "LoginRegister.View.InformacionView �� 
TargetType �� Property �� Value �� Triggers	 �� Value
 �� Binding P� Property P� Value��%�  &	        &	      (�� &     5      *, +)(�� X     5      *, +)(�� �     5      *, +)(�� �     5!      *,	 +)(�� �     5%      *, +)(��      5)      *, +)'o� R    'm� t    '�� �      5   
   62     5   
   6/   �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5!   
   " 	 6   .R�5"      
  5#      �� 5%   
   "  6   .R�5&        5'      �� 5)   
   "  6   .R�5*        5+      �� 5.   
   " o�6   .�5/      ��  � ��
 �����6+   �� 50       � ��$ 16(�6)   �� 51       � ��$
 10,5q�6(   �� 52       � ��$ Center=�64   �� 53       � ��$	 Top=�62   �� 54       � ��$ 0,20,0,0q�6'   �� 55       � ��$ 40��6'    56      �� 57      "	  6D   
 6   �� *SelectedViewModel+.a�58      ��  � y�$ 	Collapsed=�63   59      �� 5:      "	 	 6D   
 6   �� *SelectedViewModel+.a�5;      ��  � y�$ 	Collapsed=�63   5<      5>      �� 5A   
   " m�6   .�5B      ��  � ��
 ���� 6+   �� 5C       � ��$
 10,5q�6(   �� 5D       � ��$ 14(�6)   �� 5E       � ��$ Center=�64   �� 5F       � ��$ Center=�62    5G      P� 5H       �@J�IsMouseOver$
 True��61   . �5I      ��  � �� �#4A90E263   �� 5J       � ��
 �����63   5K      5M      �� 5P   
   " ��6   .�5Q      ��  � ��$ 0q�6'   �� 5S       � ��$ 0q�6(   �� 5U       � ��
 ���� 6+   �� 5W       � ��$ Stretch=�6;   �� 5X       � ��$ Stretch=�69   5Y      5[      .��5]      �  � RowDefinitions 5^   
   �� 5_      $
��Auto �6   �� 5`      $��* �6   �� 5a      $
��Auto �6   .+�5e   
   � $��0��6   .+�5f      o� 
���   �{�6&   �� *IsMenuEnabled+y�6J   �� *IsMenuVisible+ �� 	Converter# [  .@�5g      m� $��
_Dashboard��6    m� Command 6/   �� *SelectViewModelCommand+ m� CommandParameter 6Z   �� *DashboardViewModel+m� 5h      $��_Informacion��6    61   �� *SelectViewModelCommand+ 6\   �� *InformacionViewModel+m� 5i      $��_Login��6    6+   �� *SelectViewModelCommand+ 6V   �� *LoginViewModel+5j      5k      �� 5n   
   $��1��6   ��6&   �� *SelectedViewModel+5o      5p      