   M S B A M L   `   `   `  ����E  ATipsWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TipsWindow
TipsWindow  5   	       TipsWindow.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:TipsWindow     5   	   -   5          �Name$  	TipWindow��5	   	    � Title$ Tips Window��5   	   $	��450��6   $	��800��6*   .��5
      � .+�5   
   �� -   5         ��Name$ 
tipTextBox��5      $
��Left=�6&   $��49��6A   $��	10,10,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��681��6�    J� RenderTransformOrigin$ 0.307,-0.405&�6�   �� 5   
   -   5         ��Name$ businessTipCount��5      $��Business Tips��6-   $
��Left=�6D   $	��224��6_   $��	10,64,0,0q�6l   $	��Top=�6   $	��681��6�   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ businessGrid��5      $
��Left=�6-   $	��203��6H   $	��Top=�6U   $	��671��6m   $��	0,0,-2,-2q�6y   5      �� 5   
   -   5        $ friendTipCount��5      $0��*Tips from friend who reviewd this business��6+   $
��Left=�6_   $	��116��6z   $��
10,293,0,0q�6�   $	��Top=�6�   $	��681��6�   .��5        -   5        $ friendsTipGrid��5      $
��Left=�6/   $	��100��6J   $��	0,0,-2,-7q�6W   $	��Top=�6j   $	��671��6�   5      �� 5   
   -   5         ��Name$ addTipButton��5      $��Add Tip��6'   $
��Left=�69   $��
705,10,0,0q�6T   $	��Top=�6h   $��77��6�   $��49��6�   6�   �� 5   
   -   5        $ 
likeButton��5      $
��Like��6%   $
��Left=�64   $��
705,74,0,0q�6O   $	��Top=�6c   $��75��6{   $��50��6�   6�   5      5      