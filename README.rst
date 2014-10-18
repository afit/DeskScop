What is DeskScop?
-----------------
DeskScop is a desktop application that can make SpamCop far quicker and easier to work with. It provides a sortable view on your held messages, and will allow for additional user-configurable rules to be applied to the held mail.

If you find you often have many held messages to check through DeskScop can help you process your messages faster, as it is able to perform several different actions ( *quick report*, *forward*, *forward \& whitelist*, *queue*, *queue \& trash* and *delete*) on your held mail without having to reread the list through SpamCop's often-slow interface.

It is available at no cost and is a small download.

What does DeskScop look like?
-----------------------------
.. image:: http://s.reincubate.com/res/i/labs/deskscop_configuration.gif
   :alt: DeskScop's configuration screen.


.. image:: http://s.reincubate.com/res/i/labs/deskscop_action.gif
   :alt: DeskScop's action screen.
   :width: 595px

Is there anything else I should know about DeskScop?
----------------------------------------------------
Yes, a few things:

* DeskScop doesn't store your username or password anywhere. If you want the username or password fields to preload with your username and password, you can edit the configuration file by hand. DeskScop does not use the Windows registry.
* DeskScop is *not* endorsed by SpamCop.
* DeskScop uses the same basic authentication mechanism to talk to SpamCop's servers as the VER reporting system.
* DeskScop is unfinished. If it fails nastily -- unlikely as that is -- it's tough luck. Any bugs that you encounter should be reported to the author.
* You might want to send the authors an email if you'd like to contribute, too.
* DeskScop is written with .NET and will need the .NET framework installed in order to run. Version 0.9.2 requires  `.NET 2 <http://www.microsoft.com/downloads/details.aspx?FamilyID=0856eacb-4362-4b0d-8edd-aab15c5e04f5&displaylang=en>`_, earlier versions just need `.NET 1.1 <http://www.microsoft.com/downloads/details.aspx?FamilyID=262d25e3-f589-4842-8157-034d1e7cf3a3&DisplayLang=en>`_.
* This would be a whole lot easier with a bunch of regexps.

Where can I get DeskScop?
-------------------------
Please do not redistribute DeskScop without our permission. You can download DeskScop here:

*  `DeskScop 0.9.2 Beta <https://github.com/afit/DeskScop/raw/master/Release/0.9.2/DeskScop-0.9.2.zip>`_ (31st January 2006)
*  `GitHub <https://github.com/afit/DeskScop>`_ 

Change log
----------
0.9.2

* Fixed bug parsing higher-order message IDs
* Ported to .NET 2

0.9.1

* Support for entitised message IDs

0.9

* Improved support for corrupted email headers
* Added handy \"Next \>\" button
* Removed messagebox warning when DeskScop can't parse a date. Unparsable dates are set to 1970.
* Added \"are you sure you wish to reread messages when you have unprocessed messages?\" message box.
* Fixed status bar behaviour when no messages found.

0.8.2

* Fixed bug with action lookups
* Moved column width settings to configuration file

0.8.1

* Specific error message for incorrect username / password
* Date parsing patterns broken out to config
* User prompted to update date parsing patterns
* Fixed \"set all\" bug
* Added status bar with some information

0.8

* First public alpha release of DeskScop

Help! It doesn't work!
----------------------
There isn't much useful documentation yet.

* When I run DeskScop I get an \"Application Error\" message! Installing the `Microsoft .NET Framework Version 1.1 Redistributable Package <http://www.microsoft.com/downloads/details.aspx?FamilyID=262d25e3-f589-4842-8157-034d1e7cf3a3&DisplayLang=en>`_ should fix this.
* I get an error message \"An error occured parsing the sent date[...]\"! DeskScop tries to parse sent dates in your held mail into a common readable date format. However, the dates in spam email headers are not commonly well-formed. The DeskScop.exe.config configuration file lists a series of patterns. Have a poke around with it, or raise an issue in GitHub.
