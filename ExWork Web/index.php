<!doctype html>
<html lang="en">

<head>
    <title>Exwork | İş Takibinin Yeni Yolu</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,700' rel='stylesheet' type='text/css'>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">

    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/admin.css">


</head>

<body class=" bg-exwork" style="background-image: url(exwork-bg2.jpg);">
    <section class="ftco-section img bg-hero">
        <div class="container text-center">
            <h1 class="heading-section">Exwork | İş Takibinin Yeni Yolu </h1>
        </div>


        <div class="container mt-5">
            <div class="row">
                <div class="col-md-5 ml-5 mr-5">
                    <h3 class="text-white">Hemen kullanmaya başla</h3>
                    <div class="mt-5">
                        <span class="text-white h5 baslik"><span class="fa fa-check-circle text-white mr-3"></span>GÖREV
                            YÖNETİMİ:</span>
                        <p>Projenizdeki görevleri kolayca oluşturabilir, atayabilir ve takip edebilirsiniz.
                            Görevlerinizi önceliklendirme, süre belirleme ve dosya eklemeleri yapma gibi özelliklerle
                            yönetebilirsiniz. Böylece her bir görevi adım adım takip edebilir ve takımınızla etkili bir
                            şekilde işbirliği yapabilirsiniz.

                        </p>
                    </div>
                    <div class="mt-5">
                        <span class="text-white h5 baslik"> <span class="fa fa-check-circle text-white mr-3"></span> İŞ
                            PERFORMANSI İZLEME:</span>
                        <p>ExWork, projelerinizin ilerlemesini ve iş performansını izlemenize yardımcı olur. Gerçek
                            zamanlı analiz ve raporlama özellikleri sayesinde proje durumunu izleyebilir, işlerinizi
                            zamanında tamamlayabilir ve verimlilik düzeyinizi artırabilirsiniz. Ayrıca, proje
                            maliyetlerinizi ve bütçenizi izlemek için finansal analiz araçları da sunar.
                        </p>

                        <a class="btn btn-block btn-secondary text-white" href="exwork.rar"><i class="fa fa-download"
                                aria-hidden="true"></i> Hemen İndir</a>
                    </div>
                </div>              

                    <div class="col-md-5 card pr-5 pl-5">  
                    <form method="POST">  //! formun gönderim metodu post olarak belirlenmiştir post kapalı çağrı yapan bir gönderim türüdür
                    
                    <?php
                     include("baglan.php");   //!veritabanı bağlantı cümlesini çağırıyoruz
                    @$il_no = $_GET["sehir"]; //! şehiri get ile çağırıyoruz çünkü şehir seçimi yaptığımız select elementinden veriyi açık şekilde gönderiyoruz sonra sayfa tekrar yüklendiğinde bu veriyi alıp seçilen şehri otomatik seçilmiş hale getiriyoruz ve bu veri sayesinde seçilmiş olan şehre ait ilçeler listeleniyor
                    @$sehirYazdir; 
                    foreach($db->query("select * from iller where il_no='".$il_no."'")as $listeleSehir)
                    { $sehirYazdir= $listeleSehir["isim"];  }?> //! il nodan gelen plaka koduna eşit olan şehir adını değişkene atıyoruz.
                 
                   <input type="hidden" name="secilen_sehir" value="<?php echo $sehirYazdir; ?> ">  
                        <div class="cart-header h3 text-center mt-3">Kayıt Ol</div>
                        <div class="cart-body">

                            <select name="sehir" class="form-control mt-3" id="jumpMenu"
                                onchange="MM_jumpMenu('parent',this,0)"> //! şehir seçildiğinde ilçelerin gelmesi için sayfa yenileniyor. sayfa yenilenirken seçilen şehir kodunu alıyoruz.
                                <option value="">Şehir Seçiniz</option>
                                <?php 
                           

                            foreach($db->query("select * from iller")as $listele){ ?> 
                                <option <?php if($il_no==$listele["il_no"]){echo "selected=selected";} ?> value="<?php echo "index.php?sehir=".$listele["il_no"]; ?>">
                                    <?php echo $listele["isim"]; ?></option>
                                <?php } ?>
                            </select>
                            <select name="ilce" class="form-control mt-3" id="">
                                <option value="">İlçe Seçiniz</option>
                                <?php  foreach($db->query("select * from ilceler where il_no='".$il_no."'")as $listele2){ ?>
                                <option  value="<?php echo $listele2["isim"]; ?>">
                                    <?php echo $listele2["isim"]; ?></option>
                                <?php } ?>
                            </select>
                            <input type="text" name="firma_adi" class="form-control mt-3" placeholder="Firma Adı" id=""
                                required>
                            <input type="text" name="yetkili" class="form-control mt-3" placeholder="Firma Yetkilisi"
                                id="" required>
                            <input type="email" name="mail" class="form-control mt-3" placeholder="E-mail" id=""
                                required>
                            <input type="text" name="telefon" class="form-control mt-3" minlength="11" maxlength="11" placeholder="Telefon" id=""
                                required>
                            <input type="password" name="parola" class="form-control mt-3" placeholder="Parola" id=""
                                required>
                        </div>
                        <div class="cart-footer mt-3">
                            <button class="btn btn-warning btn-block mb-4">Kayıt Ol</button>

                            <?php
								if($_POST){
									$firma_adi=$_POST["firma_adi"];
									$sehir=$_POST["sehir"];
									$ilce=$_POST["ilce"];
									$yetkili=$_POST["yetkili"];
									$mail=$_POST["mail"];
									$telefon=$_POST["telefon"];
									$parola=$_POST["parola"];
                                           
                                    $say=0;
			                        @$sonuc = $db->prepare("SELECT COUNT(*) FROM firma WHERE firma_mail='{$mail}'");	
                                    @$sonuc->execute();    
                                    @$say = $sonuc->fetchColumn();    
                                    if($say==0){
                                $sql = "INSERT INTO firma (firma_adi,firma_yetkili,firma_mail,firma_telefon,firma_sehir,firma_ilce,sifre) VALUES (?,?,?,?,?,?,?)";
                                    $stmt= $db->prepare($sql);
                                    $stmt->execute([$firma_adi,$yetkili,$mail,$telefon,$sehirYazdir,$ilce,$parola]);
                                    echo '<div class="col-md-12 alert alert-success"> Kaydınız başarıyla gerçekleşti. </div>';
									}
                                }
                                if(@$say>0){
                                    echo '<div class="col-md-12 alert alert-danger"> Bu mail zaten kullanılmış</div>';
                                }
							?>

                        </div>
                        </form>
                    </div>      
            </div>
        </div>
    </section>


    <script src="js/jquery.min.js"></script>
    <script src="js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.validate.min.js"></script>
    <script src="js/main.js"></script>

    <script type="text/javascript">  //! şehir seçildiğinde ilçelerin gelmesi için sayfa yenileniyor. sayfa yenilenirken seçilen şehir kodunu alıyoruz.
    function MM_jumpMenu(targ, selObj, restore) { //v3.0
        eval(targ + ".location='" + selObj.options[selObj.selectedIndex].value + "'");
        if (restore) selObj.selectedIndex = 0;
    }
    </script>
</body>
</html>