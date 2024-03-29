﻿using System;
using System.Collections.Generic;

namespace ServiceLogic.DomainLayer.StoreFeatures.StorePolicies.CompositeDP
{
    [Serializable]
    public abstract class Composite : Component
    {
        protected List<Component> _children = new List<Component>();
        
        public override void Add(Component component)
        {
            this._children.Add(component);
        }

        public override void Remove(Component component)
        {
            this._children.Remove(component);
        }

        public List<Component> GetChildren()
        {
            return _children;
        }

        // The Composite executes its primary logic in a particular way. It
        // traverses recursively through all its children, collecting and
        // summing their results. Since the composite's children pass these
        // calls to their children and so forth, the whole object tree is
        // traversed as a result.
        
    }
}