using UnityEngine;
using System.Collections;

public interface IScenario
{
    // the result of a good choice
    void GoodResult();

    // the result of a bad choice
    void BadResult();

    // the rersult of a default choice
    void DefaultResult();

    // what happens when the scenario is complete
    void EndScenario();
}
