   M S B A M L   `   `   `  ����
  MadkDE    MadkDE.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$1  +Управление Материалами��5   	   $��Comic Sans MS)�5   	    � Icon$2 ,pack://application:,,,/Resources/AppIcon.ico��5   	   ���#FFFFFF$	��600��5   	   $	��900��6   .��5	      � ���#ABCFCE � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   $	��Top=�6:   .+�5      �� $2��,pack://application:,,,/Resources/AppIcon.png��6   $��50��5      $��0,0,10,0q�6    �� 5      $@��:Система управления материалами��6   $��24(�5      ���#546F94$��Center=�5      5      �� 5   
   $��1��6   $��10q�6"   .+�5      �� -   5        $-��'Показать поставщиков��5      $	��200��5      $��0,0,0,10q�5      ���#546F94
�������5       &   System.Windows.Controls.DataGrid  5"      -   5        $��MaterialsGrid��5"         AutoGenerateColumns$ False��6,      
IsReadOnly$
 True��6H   
�������   GridLinesVisibility$ 
Horizontal=�5$      $	��400��5%         Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Наименование��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6?   �� *Name+  5(      $ Тип��6)   	 66   �� *MaterialType.Name+  5)      $ Цена��6)   	 67   �� *	UnitPrice+  5*      $ Остаток��6)   	 6:   �� *QuantityInStock+  5+      $ Мин. кол-во��6)   	 6>   �� *MinQuantity+  5,      $ Упаковка��6)   	 6;   �� *QuantityPerPackage+  5-      $ Ед. изм.��6)   	 6;   �� *Unit+5/      �� 51      -   5        $1��+Редактировать материал��51      $	��200��52      $��0,10,0,0q�53      ���#546F94
�������56      57      58      59      