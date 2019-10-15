using UnityEditor;

public class MyMeshPostprocessor : AssetPostprocessor {
    public void OnPreprocessModel() {
        // Disable generation of materials if the file contains
        // the @ sign marking it as an animation.
        if (base.assetPath.Contains("@")) {
            ModelImporter modelImporter = (ModelImporter)base.assetImporter;
            modelImporter.generateMaterials = ModelImporterGenerateMaterials.None;
        }
    }
}
