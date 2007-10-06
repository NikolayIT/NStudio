<?
require_once("info.php");

if (!$vcenabled) die ("Version checker server is disabled!");
function getip()
{
   return $_SERVER['REMOTE_ADDR'];
}
function mysqlconnect()
{
   global $mysql_host, $mysql_user, $mysql_pass, $mysql_database;
   if (!@mysql_connect($mysql_host, $mysql_user, $mysql_pass))
   {
      switch (mysql_errno())
      {
         case 1040:
         case 2002:
            die("The server load is very high at the moment!");
         default:
            die("SQL ERROR (" . mysql_errno() . "): " . mysql_error());
      }
   }
   mysql_select_db($mysql_database) or die("SQL ERROR (" . mysql_errno() . "): " . mysql_error());
}
function mkglobal($vars)
{
   if (!is_array($vars)) $vars = explode(":", $vars);
   foreach ($vars as $v)
   {
      if (isset($_GET[$v])) $GLOBALS[$v] = mysql_escape_string ($_GET[$v]);
      //elseif (isset($_POST[$v])) $GLOBALS[$v] = unesc($_POST[$v]);
      else return 0;
   }
   return 1;
}
function adduser($os, $dotnet, $version, $manual)
{
	global $mysql_table;
	mysqlconnect();
	mysql_query("INSERT INTO $mysql_table (ip, os, dotnet, version, datetime, manual) VALUES ('".getip()."', '$os', '$dotnet', '$version', NOW(), '$manual')") or die("SQL ERROR (" . mysql_errno() . "): " . mysql_error());
}
mkglobal("os:dn:v:m");
adduser($os, $dn, $v, $m);
if ($v < $latest) echo ("New version available: $latestname!");
else echo("You have the latest version!");
if ($vctest)
{
	echo ("<br>");
	echo ("ip = " . getip() ."<br>");
	echo ("os = " . $os ."<br>");
	echo ("dotnet = " . $dn ."<br>");
	echo ("version = " . $v ."<br>");
	echo ("manual = " . $m ."<br>");
	echo ("... = " . $m ."<br>");
	echo ("datetime = " . date("Y-m-d H:i:s") ."<br>");
}
/*
... 0001 - NStudio 0.1 Alpha 1
... 0002 - NStudio 0.1 Alpha 2
... 0003 - NStudio 0.1 Alpha 3
... 0004 - NStudio 0.1 Alpha 4
... 0005 - NStudio 0.1 Alpha 5
... 0006 - NStudio 0.1 Alpha 6
... 0007 - NStudio 0.1 Alpha 7
... 0008 - NStudio 0.1 Alpha 8
... 0009 - NStudio 0.1 Alpha 9
... 0010 - NStudio 0.1 Beta 1
... 0020 - NStudio 0.1 Beta 2
... 0030 - NStudio 0.1 Beta 3
. 0040 - NStudio 0.1 Beta 4
0050 - NStudio 0.1 Beta 5
0060 - NStudio 0.1 Beta 6
0070 - NStudio 0.1 Beta 7
0080 - NStudio 0.1 Beta 8
0090 - NStudio 0.1 Beta 9
0091 - NStudio 0.1 RC 1
0092 - NStudio 0.1 RC 2
0100 - NStudio 0.10
0110 - NStudio 0.11
0111 - NStudio 0.111
1000 - NStudio 1.0
2000 - NStudio 2.0
*/
?>
