## Traffic Light Task

Please review the attached Unity project, which features a crossroad with two traffic lights. Your task is to implement the logic for signal switching based on the following rules:

| Signal        | Description                                                                                                     |
| ------------- | --------------------------------------------------------------------------------------------------------------- |
| **Red**       | Traffic may not proceed beyond the stop line or otherwise enter the intersection.                               |
| **Red/Amber** | The signal is about to change, but the red light rules do apply.                                                |
| **Amber**     | Traffic may not pass the stop line or enter the intersection unless it cannot safely stop when the light shows. |
| **Green**     | Traffic may proceed unless it would not clear the intersection before the next change of phase.                 |

The state of each traffic light must depend on the state of the other. For example, if one has a red light turned on, the other should have a green light turned on, and vice versa (simulating a real crossroad). Durations of signals must be configurable via a scriptable object.

Additionally, a simple UI is required. When a character is in front of a traffic light, the user should see a text description of the current signal (from the table above) on the screen. The UI must include a single button labeled "Drive". Clicking this button should display the text "Can drive" or "Can't drive" based on the current signal. There is no need to develop any code for character movement. However, let's assume that the character's initial position may vary. Consequently, the UI must consistently display the correct values regardless of which traffic light the character is positioned in front of.

Please **do not use** additional Unity packages (UniRX, Zenject, etc.).

### What is not important or required:

- The assets used and the prefabs initially included in the project should be sufficient. Additional assets can be added if desired.
- There is no need to set up a Light component on traffic lights; instead, just simply activate or deactivate already created colored objects.
- No need to create additional traffic lights, environment, moving objects on the road, or character movement code.

### What is assessed in the task:

- Project and code organization and structure.
- Efficiency of algorithms.
- Code readability and consistency in code style.
- Potential extendability of the system for handling more than two traffic lights in the future.
