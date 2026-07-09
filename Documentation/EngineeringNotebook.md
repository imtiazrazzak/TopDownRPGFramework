Event Bus Notes
-----------------------------------------------------------------------------
Why use an Event Bus?

Allows systems to react to events without depending directly on one another.

Player does not know about UI, Audio, Quest System, etc.

Duplicate subscriptions are allowed.

Reason:
The EventBus uses multicast delegates, and multicast delegates naturally allow the same handler to be added multiple times.

Trade-off:
This keeps the EventBus simple, but callers must manage subscription lifecycle carefully. If a handler subscribes twice and unsubscribes once, it will still be subscribed once.


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


Engineering Heuristics
----------------------
-Heuristic #1

Prefer code that communicates intent over code that is merely shorter.

-Heuristic #2

Optimize for readability, because code is read far more often than it is written.

-Heuristic #3

Design APIs that are forgiving of common mistakes when it doesn't hide bugs.

Example:

Publishing with no listeners is okay.
Unsubscribing a non-existent handler is okay.
But subscribing the same handler twice? That's a deliberate design decision we should understand.

-Heuristic #4

Depend on capabilities (IEventBus), not implementations (EventBus), when it meaningfully reduces coupling.

-Heuristic #5

During development, prefer loud failures over silent failures.

Why?

Because developers fix bugs they can see.

-Heuristic #6

When deciding between a class and a struct, don't start with:

"Stack or heap?"

Start with:

"Does this represent identity, or does it represent a value?"

-Heuristic #7

Use the compiler as a teammate.

Teach the compiler your intentions.

Then let it catch mistakes for you.

That's exactly what these:

readonly
sealed
interfaces
generic constraints

-Heuristic #8

Events are historical facts, not windows into live objects.

An event should answer:

"What happened?"

Not:

"Go ask somebody what happened."

-Heuristic #9

When designing a type, ask two separate questions:

Does this represent an identity or a value?
Should this value be allowed to change after it is created?

-Heuristic #10

Before creating a new type, ask these three questions:

1. What am I modeling?

A thing?

Or a value?

2. Does it have identity?

Yes?

Probably a class.

No?

Consider a struct.

3. Should it ever change after it's created?

Yes?

Mutable.

No?

readonly.

-Heuristic #11

A good public API should tell a story before you read the implementation.

-Heuristic #12

Constructors should create valid objects.

-Heuristic #13

A class should describe what happened, not orchestrate every consequence.

-Heuristic #14

When you see a generic type like:

<T>

don't immediately ask:

"What is T?"

Instead ask:

"Where is T used?"

Because that's what tells you why the generic exists.