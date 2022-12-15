﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSpan.Common
{
  public abstract class BaseMessage
  {
    protected Guid _correlationId = Guid.NewGuid();
    public Guid CorrelationId() => _correlationId;
  }
}