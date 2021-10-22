using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace aspnet.Controllers
{
    public class KullaniciController:ApiController
    {
        aspnetEntities _ent = new aspnetEntities();
        [HttpGet]
        public List<Kullanici> TumKullanicilariGetir()
        {
            return _ent.Kullanici.ToList();
        }
        [HttpGet]
        public List<Kullanici> KullaniciAra(string kelime)
        {
            return _ent.Kullanici.Where(p => p.AdSoyad.Contains(kelime)
                                            || p.MailAdresi.Contains(kelime)
                                            || p.Telefon.Contains(kelime)).ToList();
        }
        [HttpGet]
        public Kullanici KullaniciGeirIDyeGore(int KullaniciID)
        {
            return _ent.Kullanici.Find(KullaniciID);
        }
        [HttpGet]
        public List<Kullanici> KullaniciSilID(int KullaniciID)
        {
            try
            { 
            Kullanici k = _ent.Kullanici.Find(KullaniciID);
            if (k != null)
            {
                _ent.Kullanici.Remove(k);
                _ent.SaveChanges();
                
            }
                return TumKullanicilariGetir();
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        [HttpPost]
        public List<Kullanici> KullaniciEkle(Kullanici veri)
        {
            try
            {
                _ent.Kullanici.Add(veri);
                _ent.SaveChanges();
                return TumKullanicilariGetir();
            }
            catch (Exception)
            {
                return null;
            }

        }
        [HttpPost]
        public bool KullaniciGuncelle(Kullanici yeni)
        {
            try
            {
                Kullanici eski = _ent.Kullanici.Find(yeni.KullaniciID);
                eski.AdSoyad = yeni.AdSoyad;
                eski.MailAdresi = yeni.MailAdresi;
                eski.Telefon = yeni.Telefon;
                _ent.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}