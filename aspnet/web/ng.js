var app = angular.module("uygulama", []);
app.controller("kullanicictrl", function ($scope, $http) {
    $http.get("http://localhost:56520/api/Kullanici/TumKullanicilariGetir")
        .then(function (response) {
            $scope.kullanicilistesi = response.data;
        });
    $scope.kullanicisil = function (id) {
        $http.get("http://localhost:56520/api/Kullanici/KullaniciSilID?KullaniciID="+id)
            .then(function (response) {
                $scope.kullanicilistesi = response.data;
            });
    }
    $scope.idyegoregetir = function (sayi) {
        $http.get("http://localhost:56520/api/Kullanici/KullaniciGeirIDyeGore", { params: { KisiID: sayi } })
            .then(function (response) {
                $scope.idyegoregelen = response.data;
            });
    }
    $scope.telegoregetir = function (tel) {
        $http.get("http://localhost:56520/api/Kullanici/KullaniciGeirIDyeGore", { params: { Tel: tel } })
            .then(function (response) {
                $scope.idyegoregelen = response.data;
            });
    }
    $scope.kullaniciekle = function (veri) {
        $http.post("http://localhost:56520/api/Kullanici/KullaniciEkle", veri)
            .then(function (response) {

                $scope.kullanicilistesi = response.data;
                $scope.kullanici = {};
            });
    }
    $scope.kullaniciguncelle = function (veri) {
        $scope.kullanici = veri;
    }
    $scope.guncelle = function (yeni) {
        $http.post("http://localhost:56520/api/Kullanici/KullaniciGuncelle", yeni)
            .then(function (response) {
                if (response.data == true) {
                    $http.get("http://localhost:56520/api/Kullanici/TumKullanicilariGetir")
                        .then(function (response) {
                            $scope.kullanicilistesi = response.data;
                            alert("Guncelleme islemi basariyla tamamlandi");
                        });
                }
                else alert("Kullanici guncelleme islemi sirasinde bir hata olustu");
                $scope.kullanici = {};
            });
    }
});