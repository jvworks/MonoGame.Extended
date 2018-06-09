﻿using System;

namespace MonoGame.Extended.Entities
{
    public class Entity : IEquatable<Entity>
    {
        private readonly ComponentManager _componentManager;

        public Entity(int id, ComponentManager componentManager)
        {
            Id = id;
            _componentManager = componentManager;
        }

        public int Id { get; }

        public void Attach<T>(T component)
            where T : class 
        {
            var mapper = _componentManager.GetMapper<T>();
            mapper.CreateComponent(Id, component);
        }

        public void Detach<T>()
            where T : class
        {
            var mapper = _componentManager.GetMapper<T>();
            mapper.DeleteComponent(Id);
        }

        public T Get<T>()
            where T : class 
        {
            var mapper = _componentManager.GetMapper<T>();
            return mapper.GetComponent(Id);
        }

        public void Destory()
        {
            throw new NotImplementedException();
        }

        public bool Equals(Entity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Entity) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Entity left, Entity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !Equals(left, right);
        }
    }
}