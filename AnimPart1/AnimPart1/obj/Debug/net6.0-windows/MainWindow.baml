   M S B A M L   `   `   `  ����D  @AnimPart1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AnimPart1	AnimPart1  5   	       AnimPart1.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:AnimPart1     5   	     � Title$  
MainWindow��5   	   $
��1104��6   $
��1342��6*    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType � ColumnDefinitions ��Name �� CornerRadius	 A�Name
 J� RenderTransformOrigin T� X'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%�  'd�       �� 5   
   " d�6   .�5      ��  � �� �#3336+   �� 5       � �� 5      �� 5      " d�6&   .R�5      � $��32��6   
������  5      �� 5   "   $
��Auto �63   �� 5   "   $
��Auto �63   �� 5   "   $��* �63   .+�5      �� $ TrackBorder��6%   $��0��6:   $��3��6J   $ 16��6^   $��24��6p   
�������._�5   "   �� $��Center=�63   $��Center=�6P   5      � 5      $��0��6#   $��Center=�63   .+�5   "   A� $	 Thumb��6*   
���   �$��24��6F   $��24��6Q   $
 0.5,0.5&�6]   z�5   &   T� 5    *   $ 0Q�6=   5"   #   5#      �� 5&      $��2��6(   #��z��68   $��Center=�6Y   #��z��6t    5(        5)   "   CheckStates��. 5*   &     Checked��. 5+   *   �� .��5,   .   �� $ TrackBorder��6K   $1 +(Border.Background).(SolidColorBrush.Color)�6o   .g�5-   2     $ 0��6F   $ #4CAF50��6R   5.   /   U� 5/   .   $ Thumb��6L   $8 2(UIElement.RenderTransform).(TranslateTransform.X)�6j   .\�50   2     $ 0��6G   $ 24Q�6S   51   /   52   +   53   '     54   &   	Unchecked��. 55   *   �� .��56   .   �� $ TrackBorder��6K   $1 +(Border.Background).(SolidColorBrush.Color)�6o   .g�57   2     $ 0��6F   $
 Gray��6R   58   /   U� 59   .   $ Thumb��6L   $8 2(UIElement.RenderTransform).(TranslateTransform.X)�6j   .\�5:   2     $ 0��6G   $ 0Q�6S   5;   /   5<   +   5=   '   5>   #   5A      5B      5D      5E      5F      .��5H      �  5I   
   �� 5J      $
��447* �6   �� 5K      $
��353* �6    � RowDefinitions 5N   
   �� 5O      $
��Auto �6   �� 5Q      $��* �6   .+�5U   
   �� $��
TANK (001)��6   $
��Left=�6'   $��Center=�6B   $	��195��6]   .��5V      � $	��142��6    5W      �� 5X      $
��Auto �6$   �� 5Y      $
��Auto �6$   �� 5Z      $
��Auto �6$   .+�5^      � $��0��6    5_      �� 5`      $
��Auto �6+   �� 5a      $��* �6+   .+�5c      �� $��Label��6    $��Center=�6-   $��5q�6H   d� 5d      -   5        $�� ��5d   #   $��5q�6.   $��50��69   $��30��6D   $��1��6P   6`   5e      � 5h      $��1��6    5i      �� 5j      $
��Auto �6+   �� 5k      $��* �6+   .+�5m      �� $��Lights��6    $��Center=�6.   $��5q�6I   d� 5n      $�� ��6#   $��5q�6.   $��50��69   $��30��6D   $��1��6P   5o      � 5r      $��2��6    5s      �� 5t      $
��Auto �6+   �� 5u      $��* �6+   .+�5w      �� $��Camera��6    $��Center=�6.   $��5q�6I   d� 5x      $�� ��6#   $��
36,0,47,10q�6.   $��50��6B   $��30��6M   $��1��6Y   5y      5z      5{      � 5~   
   $��1��6   $��2��6    5�      �� 5�      $
��401* �6    �� 5�      $	��92* �6    �� 5�      $	��86* �6    �� 5�      $
��132* �6    �� 5�      $	��71* �6    �� 5�      $	��37* �6    .+�5�      � $��0��6   $��0,0,0,3q�6     5�      �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   .+�5�      �� -   5         ��Name$ ThirdColumn��5�   1   $��2��6!   61   5�      � 5�      $��	0,323,0,1q�6   $��2��6&    5�      �� 5�      $
��160* �6'   �� 5�      $
��287* �6'   �� 5�      $
��147* �6'   �� 5�      $
��301* �6'   �� 5�      $
��447* �6'   .+�5�      �� -   5        $ FirstThirdColumn��5�   !   $��4��6;   5�      �� 5�      $��3��6   $��0,15,0,9q�6*   �� 5�      $��4��6   $��0,4,0,0q�6*   �� 5�      $��5��6   $��0,9,0,0q�6*   5�      �� 5�   
   $��HOPPER (004)��6   $��	390,0,0,0q�6)   $
��Left=�6<   $��Center=�6W   .��5�      � $	��142��6    5�      �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   .+�5�      � $��0��6   $	��Top=�6$    5�      �� 5�      $
��Auto �6+   �� 5�      $��* �6+   .+�5�      �� $��Label��6    $��Center=�6-   $��5q�6H   d� 5�      $�� ��6#   $��5q�6.   $��50��69   $��30��6D   $��1��6P   5�      � 5�      $��1��6    5�      �� 5�      $
��Auto �6+   �� 5�      $��* �6+   .+�5�      �� $��Lights��6    $��Center=�6.   $��5q�6I   d� 5�      -   5        $�� ��5�   #   $��5q�6.   $��50��69   $��30��6D   $��1��6P   6�   5�      � 5�      $��2��6    5�      �� 5�      $
��Auto �6+   �� 5�      $��* �6+   .+�5�      �� $��Camera��6    $��Center=�6.   $��5q�6I   d� 5�      -   5        $�� ��5�   #   $��	26,5,32,5q�6.   $��50��6A   $��30��6L   $��1��6X   6�   5�      5�      5�      �� 5�   
   $��
SILO (015)��6   $��	210,0,0,0q�6'   $
��Left=�6:   $��Center=�6U   .��5�      � $	��142��6    5�      �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   �� 5�      $
��Auto �6$   .+�5�      � $��0��6    5�      �� 5�      $
��Auto �6+   �� 5�      $��* �6+   .+�5�      �� $��Label��6    $��Center=�6-   $��5q�6H   d� 5�      -   5        $�� ��5�   #   $��5q�6.   $��50��69   $��30��6D   $��1��6P   6`   5�      � 5�      $��1��6    5�      �� 5�      $
��Auto �6+   �� 5�      $��* �6+   .+�5�      �� $��Lights��6    $��Center=�6.   $��5q�6I   d� 5�      $�� ��6#   $��5q�6.   $��50��69   $��30��6D   $��1��6P   5�      � 5�      $��2��6    5�      �� 5�      $
��Auto �6+   �� 5�      $��* �6+   .+�5�      �� $��Camera��6    $��Center=�6.   $��5q�6I   d� 5�      $�� ��6#   $��	24,5,33,5q�6.   $��50��6A   $��30��6L   $��1��6X   5�      5�      5�      5�      5�      