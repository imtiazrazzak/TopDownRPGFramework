Event Bus Notes
-----------------------------------------------------------------------------
Why use an Event Bus?

Allows systems to react to events without depending directly on one another.

Player does not know about UI, Audio, Quest System, etc.


IEvent
------
Marker interface.

Purpose:

Restrict Publish() to only framework event types.

Compiler enforces this.

Generics
---------
Publish<TEvent>()

Means:

Preserve the specific event type instead of treating everything as IEvent.


Dictionary<Type, Delegate>
--------------------------

Question being answered:

"Given an event type, who is listening?"

Dictionary chosen because lookup is the primary operation.


Type
-----

Represents metadata describing a C# type.

Used as the dictionary key.


Delegate
---------

Reference to one or more methods.

Multicast delegates internally maintain an invocation list.


Immutability
-------------

Delegates are immutable.

Combine() creates a new delegate.

Original delegate never changes.

Provides stronger guarantees and avoids shared mutable state.


Failure Modes
-------------
Duplicate subscriptions
Forgetting to unsubscribe
Exceptions in handlers
Recursive events
Threading assumptions

Sealed
--------
This is an indication of a complete implementation. It cannot be inherited from. If a different behavior is desired, then a different class is needed.

