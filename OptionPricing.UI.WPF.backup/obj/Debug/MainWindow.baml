   M S B A M L   `   `   `  ????  OptionPricing.UI.WPF%    OptionPricing.UI.WPF.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $	??600??5   #   $	??800??60     ? Title  6	   ?? *	AppName+ ? DataContext 5   	   ??    Locator ?? Source# [   ?? Path$
 Main?.??5
      ?  ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   .+?5   
   ?? $??14(?6   $??Center=?6   $??Center=?6;   $??1??6V   $??0??6c   .??6s   Stock Price5      ?? 5   
   $??1??6   $??1??6   $&?? Binding StockPrice, Mode=TwoWay}??6/   ?? 5   
   $??14(?6   $??Center=?6   $??Center=?6;   $??2??6V   $??0??6c   .??6s   
Volatility5       ?? 5!   
   $??2??6   $??1??6   $&?? Binding StockPrice, Mode=TwoWay}??6/   5"      5$      