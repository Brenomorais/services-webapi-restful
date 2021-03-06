﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UsuarioModel
    {
        private int codigo;
        private string nome;
        private string login;

        public UsuarioModel()
        {

        }

        public UsuarioModel(int codigo, string nome, string login)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.login = login;
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

    }
}