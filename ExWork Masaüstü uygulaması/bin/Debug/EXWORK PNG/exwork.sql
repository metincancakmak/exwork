-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 20 May 2023, 15:17:12
-- Sunucu sürümü: 10.4.21-MariaDB
-- PHP Sürümü: 7.4.23

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `exwork`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ajanda`
--

CREATE TABLE `ajanda` (
  `ajanda_id` int(11) NOT NULL,
  `ajanda_tur` varchar(55) COLLATE utf8_turkish_ci NOT NULL,
  `olusturan_id` varchar(5) COLLATE utf8_turkish_ci NOT NULL,
  `olusturma_tarih` date NOT NULL,
  `baslik` varchar(55) COLLATE utf8_turkish_ci NOT NULL,
  `icerik` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `ajanda_tarih` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `firma`
--

CREATE TABLE `firma` (
  `firma_id` int(11) NOT NULL,
  `firma_adi` varchar(55) COLLATE utf8_turkish_ci NOT NULL,
  `firma_yetkili` varchar(55) COLLATE utf8_turkish_ci NOT NULL,
  `firma_mail` varchar(55) COLLATE utf8_turkish_ci NOT NULL,
  `firma_telefon` varchar(55) COLLATE utf8_turkish_ci NOT NULL,
  `firma_sehir` varchar(55) COLLATE utf8_turkish_ci NOT NULL,
  `firma_ilce` varchar(55) COLLATE utf8_turkish_ci NOT NULL,
  `sifre` varchar(55) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `gorevler`
--

CREATE TABLE `gorevler` (
  `gorev_id` int(11) NOT NULL,
  `firma_id` varchar(5) COLLATE utf8_turkish_ci NOT NULL,
  `personel_id` varchar(5) COLLATE utf8_turkish_ci NOT NULL,
  `gorev_tur` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `gorev` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `verilis_tarih` date NOT NULL,
  `son_tarih` date NOT NULL,
  `tamamlandimi` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `tamamlanma_tarih` date NOT NULL,
  `puan` varchar(5) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `personel`
--

CREATE TABLE `personel` (
  `personel_id` int(11) NOT NULL,
  `ad` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `soyad` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `mail` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `telefon` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `sifre` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `departman` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `gorev` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `rol` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `firma_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `personel`
--

INSERT INTO `personel` (`personel_id`, `ad`, `soyad`, `mail`, `telefon`, `sifre`, `departman`, `gorev`, `rol`, `firma_id`) VALUES
(1, '0', '0', '0', '0', '124242', '0', '0', '0', 1),
(2, 'hasan', 'unutkan', 'hasangmail.', '34354533434', '518181', 'Yazılım', 'Front End', 'personel', 1);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `ajanda`
--
ALTER TABLE `ajanda`
  ADD PRIMARY KEY (`ajanda_id`);

--
-- Tablo için indeksler `firma`
--
ALTER TABLE `firma`
  ADD PRIMARY KEY (`firma_id`);

--
-- Tablo için indeksler `gorevler`
--
ALTER TABLE `gorevler`
  ADD PRIMARY KEY (`gorev_id`);

--
-- Tablo için indeksler `personel`
--
ALTER TABLE `personel`
  ADD PRIMARY KEY (`personel_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `ajanda`
--
ALTER TABLE `ajanda`
  MODIFY `ajanda_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `firma`
--
ALTER TABLE `firma`
  MODIFY `firma_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `gorevler`
--
ALTER TABLE `gorevler`
  MODIFY `gorev_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `personel`
--
ALTER TABLE `personel`
  MODIFY `personel_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
