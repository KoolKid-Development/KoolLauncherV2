
# KoolLauncherV2

This is a custom minecraft launcher for you minecraft server!





## Features

- AutoServerJoiner
- MySQL
- Admin Page
- All Minecraft Versions




## Used By

This project is used by the following companies:

- NoxlCraft
- If you are using it and you want your name here dm me on discord KoolKid#8483


## License

[MIT](https://choosealicense.com/licenses/mit/) 


## Requirements

To run this project, you will need to have some things

`Remote MySQL Database` You can get 1 for free on our discord server if you make a ticket!

`Webhost` https://www.hostinger.com/web-hosting

`PHP` Most time you get it with your webhost

`PhPMyAdmin` https://phpmyadmin.co or use your webhost version!

`Visual Studio` https://visualstudio.microsoft.com

`KoolWeb` https://github.com/KoolKid-Development/KoolWeb


## Installation

### Options

1 - Normal Installation

2 - Easy Installation = Make a ticket on this discord server: https://discord.gg/jrgcrME3Bs
but this thing is gona require some things like your server information 1 off our staff team
is gona ask you for that.

### Downloading the project!
First you have to download the project from here
```bash
git clone https://github.com/KoolKid-Development/KoolLauncherV2.git
```
or download it from this link: https://kool-kid.xyz/download/koollauncher.zip
## Setting Up MySQL
First you have to login phpmyadmin then go to `SQL TAB` and paste this code
To execute this command press `CTRL + ENTER` on your keyboard
```sql
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";
CREATE DATABASE IF NOT EXISTS KoolWeb;
USE KoolWeb;
CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
USE KoolWeb;
CREATE TABLE `adminusers` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
ALTER TABLE `adminusers`
  ADD PRIMARY KEY (`id`);
ALTER TABLE `adminusers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
 COMMIT;
```
Now if your provider dose not allow you to create databases via phpmyadmin go to your panel and make a databases
after that go to phpmyadmin with your database name database username name and database passowrd
and go to `SQL` TAB  and paste this
```sql
CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
CREATE TABLE `adminusers` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
ALTER TABLE `adminusers`
  ADD PRIMARY KEY (`id`);
ALTER TABLE `adminusers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;
```
Now there is another option whitch is by using my file: 

https://kool-kid.xyz/download/KoolWeb.sql

And now we are done with the mysql part
### Setting up project
Use this tutorial to make the launcher here is the png to ico website that i used in the tutorial:
https://convertico.com
[![Video is not ready](https://img.youtube.com/vi/KlG9Oo4cNFI/0.jpg)](https://www.youtube.com/watch?v=KlG9Oo4cNFI)


## Deployment

To deploy this project go to the project folder witch is bin/Release and delete everything except the exe file 

