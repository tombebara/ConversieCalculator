   M S B A M L   `   `   `  ����N  JConversiecalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ConversiecalculatorConversiecalculator  5      R NSystem.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089>.clr-namespace:System.Data;assembly=System.DataSystem.Data 5      $    Conversiecalculator.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      3local!clr-namespace:Conversiecalculator     5      ?Data.clr-namespace:System.Data;assembly=System.Data     5        � Title$  Conversie Calculator��5      $	��800��5	      $	��450��5
       � WindowStartupLocation$ CenterScreen=�5      ���#181735 � 	Resources 5      )  #System.Data.SchemaSerializationMode -  )ConversiesDataSetSchemaSerializationMode1��%/   &	         5   
   IncludeSchema=�6h   5      .��5      �� -   5         ��Name$
 Main��5       �� TabStripPlacement$	 Top=�6   .@�5   
   �� -   5         ��Name$ TiMoney��5      $��Geld converteren��6#   .��5      � ���#181735 � RowDefinitions 5      �� 5      $��50 �6$   �� 5       � ColumnDefinitions 5      �� 5      $	��21* �6'   �� 5      $
��108* �6'   �� 5      $	��12* �6'   �� 5      $
��256* �6'   .+�5       � $��4��6    5!      �� 5"      $
��199* �6+   �� 5#      $	��66* �6+   �� 5$      $	��29* �6+   �� 5%      $
��235* �6+   �� 5&      $
��265* �6+   .+�5)      �� $��Conversie Calculator��6    
�������$��3��5+       $��Center=�5,       $
��Left=�5-       $��	Helvetica)�5.       $��22(�5/       $��1,0,0,0q�6.   50      �� 52      $��1��6   $��4��6*   .+�53      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�54   !   $��40��55   !   .+�56      �� $��Resultaat: ��6$   
�������$��22(�58   $   �� 5:      -   5        	 ��Name$	 ConversionResult��5:       
�������$��22(�5<       5=      �� 5?      $ 
Horizontal=�6!   $��Center=�5@   !   $��Bottom=�5A   !   .+�5B      �� $��Vul hier het getal in:��6    
�������$��16(�5D       $	��167��6.   �� 5F      $
��Van:��6    
�������$��16(�5H       $��0,0,70,0q�5I       $��58��62   �� 5K      $��Naar:��6    
�������$��16(�5M       $��	80,0,00,0q�5N       $	��150��63   5O      �� 5Q      $ 
Horizontal=�6!   $��Center=�5R   !   $	��Top=�5T   !   .+�5U      �� -   5        
 ��Name$
 UserInputValue��5U   "   $	��150��5V   "   $��25��5W   "   $��10q�5X   "   5Y   "   �� 5[      -   5         ��Name$ CmbFromValue��5\   #   $	��150��5[   #   $��10q�5\   9   $��25��5]   #    �� MaxDropDownHeight$	 150��6/   �� 5_      -   5         ��Name$ SwapCmbValues��5_   !   $��14(�68   $��25��5`   !   $��25��5a   !   $��10q�6,   .��5c      �� $��images/swap.png��6$   5d      �� 5e      -   5        $ 
CmbToValue��5f   #   $	��150��5e   #   $��14(�6/   $��25��5g   #   $	 150��6/   $��10q�6G   5h      �� 5k      $ 
Horizontal=�6!   $��Center=�5l   !   $	��200��5m   !   .+�5n      �� -   5        $ Convert��5n   !   $��
Converteer��5o   !   $��25��5p   !   $	��150��5q   !   $��Center=�5r   !   $��Center=�5s   !   $��10q�5t   !   5u   !   �� 5v      -	   5        $ ResetConversion��5v   !   $��Reset��5w   !   $��25��5x   !   $	��150��5y   !   $��Center=�5z   !   $��Center=�5{   !   $��10q�5|   !   5}   !   5~      5      5�      5�      �� 5�   
   -
   5        $ 	TiHistory��5�      $��Conversie geschiedenis��6%   $��20��6E   $	��Top=�6Q   .��5�      � ���#181735 5�      �� 5�      $��40 �6$   �� 5�      $��* �6$   �� 5�      $��25 �6$    5�      �� 5�      $��* �6'   .+�5�      �� $��Conversie geschiedenis��6   
�������$��0��5�       $��Center=�5�       $��	Helvetica)�5�       $��22(�5�       �� 5�      $
��Auto=�6   $��1��6B   .��5�      �� .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ 	DgHistory��5�   #      	RowHeight$ 25Q�5�   5   $��15(�6D    � DataContext 5�      *   $Conversiecalculator.ConversieHistory  5�   "   5�      5�      5�      �� 5�      -   5        $ DeleteHistory��5�   :   $��2��5�      $��Center=�5�      $��Verwijder Geschiedenis��5�      $��25��5�      $	��150��5�      $��Bottom=�5�      5�      5�      5�      5�      5�      