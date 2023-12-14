using UnityEngine;

public static class GameUtil {
    public static bool TryGetPlayer(out GameObject player) {
        player = GameObject.FindGameObjectWithTag("Player");
        return player != null;
    }
}
