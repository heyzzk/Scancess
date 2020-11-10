# Scancess
Scancess=Scan+Process.  
  
Scancess is a Windows c# project developed for factory to process the information captured by a USB scanner. It's not the non-focus-capture. So the foucs should be in the TextBox.
The information captured by scanner is ended with /r/n. They will be split with ';' into different fields and finally saved into CSV file.  
  
ENV:win7 + VS2019 + KR-230 usb scanner  
  
----------------------CN----------------------  
Scancess用来处理USB扫描枪获取的信息，并不是无焦点获取，所以焦点必须在textbox内。获取到的信息以/r/n结尾，再被以;号分割为不同字段，然后存入csv文件。
  
开发环境：win7 + VS2019 + 科然KR-230扫描枪  
  
TODO:  
1.字段（SSID、mac）合法性检查  
4.禁止手动输入。输入异常处理。  
5.文件保存路径选择、命名。  
6.扫描数量统计。  
7.每24个自动写到新文件。  
9.界面美化。  
  
V0.1  
![image](https://github.com/heyzzk/Scancess/blob/main/Scancess/debug/release/v0.5-20201110/ui.png)  
