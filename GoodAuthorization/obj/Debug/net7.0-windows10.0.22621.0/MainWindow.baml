   M S B A M L   `   `   `  ����L  HGoodAuthorization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GoodAuthorizationGoodAuthorization  5   	   "    GoodAuthorization.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     60   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   -localclr-namespace:GoodAuthorization   5   	   -   5        $��form1��5   	   0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��5   6    � Title$ 
MainWindow��5   H   $	��450��6[   $	��800��6h    � 	Resources 5         ButtonTemplate1 �� 
TargetType��%<   &	        �� 5	   
   " ��62   .R�5
      � 5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $	��200 �6   �� 5      $��10 �6   .+�5   
   o� $��0��6   $��30��6   $	��Top=�6(   .@�5      m� -   5        $��
Выйти��5      6&   5      �� 5   
   -   5         ��Name$ warmingCapa��5      $��	400 0 0 0q�6)   6>   �� 5   
   $��1��6   $	��Top=�6"    �� Orientation$ Vertical=�6:    K� ZIndex$ 1��6Q   $��
-10,0,10,0q�6b   .+�5      �� -   5         ��Name$ fildForInputLogin��5   '   $ 1��6   $	��400��6B   $��40��6N   �� 5      -   5        	 ��Name$	 Buuton1��5   6   $��
Войти��6   $ 0��6%   $��340 100 100 10q�6]   $��35��5      $	��100��6!   
 J� RenderTransformOrigin$
 -0.052,0.603&�6-   5       5!      �� 5%   
   -   5        $��imageForCaptah��5%      $	��100��6&   $	��100��62   $y�Visible=�6?   $��2��6T   $��342,15,358,-105q�6a   �� 5&   
   -   5        $��fildForInputPassword��5&   #   $ 2��6   $��40��6?   $��200,80,200,80q�6K   $��1��6b   �� 5'   
   -   5        $��fildForInputCaptha��5'   $   $ 0��6   $��40��6>   $��6,130,14,-160q�6J   $��2��6a   �� 5(   
   -	   5        $#��Проверить капчу��5(      $��582,141,0,0q�6+   $	��Top=�6@   $��1��6m   5)      5+      