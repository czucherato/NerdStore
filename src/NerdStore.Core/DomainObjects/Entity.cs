﻿using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;

namespace NerdStore.Core.DomainObjects
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        private readonly List<Event> _notificacoes;
        public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();

        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetHashCode().GetHashCode() * 907 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }

        public void AdicionarEvento(Event @event)
        {
            _notificacoes.Add(@event);
        }

        public void RemoverEvento(Event @event)
        {
            _notificacoes.Remove(@event);
        }

        public void LimparEventos()
        {
            _notificacoes.Clear();
        }
    }
}