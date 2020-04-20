using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adic;


namespace Adic.StartDialogue
{

    public class GameRoot : ContextRoot
    {

        public DialogueTrigger trigger;

        public override void SetupContainers()
        {
            // Create a container
            var container = this.AddContainer<InjectionContainer>();
            // Register a command that will be from DialogueManager
            container = container.RegisterExtension<CommanderContainerExtension>().RegisterCommand<DialogueManager>();

            // Bind the class to itself
            container.Bind<DialogueManager>().ToSelf();

        }

        public override void Init()
        {
            // Empty
        }

    }
}

