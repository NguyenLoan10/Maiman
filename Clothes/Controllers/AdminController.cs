﻿using Clothes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace Clothes.Controllers
{
    public class AdminController : Controller
    {
        Model1 db = new Model1();
    
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(db.KHACHHANG.ToList());

        }
        public ActionResult Chitiet(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var kh = from khach in db.KHACHHANG where khach.MAKH == id select khach;
                return View(kh.SingleOrDefault());
            }
        }
        [HttpGet]
        public ActionResult Xoa(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else

            {
                var kh = from lsp in db.KHACHHANG where lsp.MAKH == id select lsp;
                return View(kh.SingleOrDefault());
            }
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult Xacnhan(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                KHACHHANG kh = db.KHACHHANG.SingleOrDefault(n => n.MAKH == id);
                db.KHACHHANG.Remove(kh);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var ten = collection["username"];
            var mk = collection["password"];
            if (String.IsNullOrEmpty(ten))
            {
                ViewData["Loi1"] = "Nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(mk))
            {
                ViewData["Loi2"] = "Nhập mật khẩu";
            }
            else
            {

                ADMIN ad = db.ADMINs.SingleOrDefault(n => n.UserAdmin == ten && n.PassAdmin == mk);
                if (ad != null)
                {

                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "Admin");

                }
                else
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        public ActionResult SanPham(int? page)

        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            return View(db.SANPHAMs.ToList().OrderBy(n => n.MASP).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]

        public ActionResult Themmoisp()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            ViewBag.MALOAI = new SelectList(db.LOAISPs.ToList().OrderBy(n => n.TENLOAI), "MALOAI", "TENLOAI");
            ViewBag.MANCC = new SelectList(db.NCCs.ToList().OrderBy(n => n.TENNCC), "MANCC", "TENNCC");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Themmoisp(SANPHAM sp, HttpPostedFileBase fileupload)
        {
            ViewBag.MALOAI = new SelectList(db.LOAISPs.ToList().OrderBy(n => n.TENLOAI), "MALOAI", "TENLOAI");
            ViewBag.MANCC = new SelectList(db.NCCs.ToList().OrderBy(n => n.TENNCC), "MANCC", "TENNCC");
            if (fileupload == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Public/img"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    else
                    {
                        fileupload.SaveAs(path);
                    }
                    sp.ANHBIA = fileName;
                    db.SANPHAMs.Add(sp);
                    db.SaveChanges();
                }
                return RedirectToAction("SanPham");
            }

        }

        public ActionResult ChitietSP(int id)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            ViewBag.MaSP = sp.MASP;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
        [HttpGet]
        public ActionResult XoaSP(int id)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            ViewBag.MASP = sp.MASP;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }

        [HttpPost, ActionName("XoaSP")]

        public ActionResult Xacnhanxoa(int id)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            ViewBag.MASP = sp.MASP;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SANPHAMs.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("SanPham");
        }

        [HttpGet]

        public ActionResult SuaSP(int id)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MALOAI = new SelectList(db.LOAISPs.ToList().OrderBy(n => n.TENLOAI), "MALOAI", "TENLOAI", sp.MALOAI);
            ViewBag.MANCC = new SelectList(db.NCCs.ToList().OrderBy(n => n.TENNCC), "MANCC", "TENNCC", sp.MANCC);

            return View(sp);
        }
        [HttpPost, ActionName("SuaSP")]
        [ValidateInput(false)]
        public ActionResult Capnhat(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == id);
                UpdateModel(sp);
                db.SaveChanges();
                return RedirectToAction("SanPham");
            }
        }

    }
}