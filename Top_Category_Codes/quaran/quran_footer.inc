<%
Dim FooterString
Dim FooterTempaltes(1)
Dim RandNum
FooterTempaltes(0)=Array(" ������ ������ ���������� �������� ���������� ���������  ", " [ ������� ����� 23] ")
FooterTempaltes(1)=Array(" ������ ������ ���������� ��������� �������� ���� ������������ ", " [ ����� ����� 9] ")
Randomize
'int((max-min+1)*rnd+min)
RandNum=int((ubound(FooterTempaltes)+1)*rnd)
FooterString=FooterTempaltes(RandNum)
%>
<hr color="#007F00">
<p align="center">
<b>
<font face="AGA Arabesque" color="blue">
]
</font>
<%=FooterString(0)%>
<font face="AGA Arabesque" color="blue">
[
</font>
</b>
<BR>
<%=FooterString(1)%>
</p>
<p align="center"><font face="Simplified Arabic" size="2"><b><span lang="ar-qa">
<a href="http://www.alnoor-world.com/">���� �����</a></span></b></font></p>

</HTML>